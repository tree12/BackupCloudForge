package eatlab.dms.server;


import eatlab.dms.common.domain.UserData;
import io.jsonwebtoken.Claims;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.security.SecurityProperties;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.core.annotation.Order;
import org.springframework.core.env.Environment;
import org.springframework.security.authentication.AuthenticationProvider;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.AuthenticationException;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.web.authentication.WebAuthenticationDetailsSource;
import org.springframework.security.web.authentication.preauth.PreAuthenticatedAuthenticationToken;
import org.springframework.security.web.authentication.www.BasicAuthenticationFilter;
import org.springframework.web.cors.CorsConfiguration;
import org.springframework.web.cors.CorsConfigurationSource;
import org.springframework.web.cors.UrlBasedCorsConfigurationSource;
import org.springframework.web.filter.GenericFilterBean;

import javax.servlet.FilterChain;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpServletRequest;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.nio.charset.StandardCharsets;
import java.util.*;
import java.util.stream.Collectors;

/**
 * Created by aklaffenboeck on 8/9/2017.
 * CSRF-Implementation:
 * siehe http://stackoverflow.com/questions/36878189/invalid-csrf-token-in-post-request
 */

@Configuration
@EnableWebSecurity
@EnableGlobalMethodSecurity(
        prePostEnabled = true,
        securedEnabled = true,
        jsr250Enabled = true)
@Order(SecurityProperties.ACCESS_OVERRIDE_ORDER)
public class SecurityConfig extends WebSecurityConfigurerAdapter {



    public static final String SECRET = "§%fggh<839dsfdasf3221)(&/";
    public static final long EXPIRATION_TIME = 86400000; // 1 day
    public static final String TOKEN_PREFIX = "EatLab ";
    public static final String HEADER_STRING = "Authorization";

    @Autowired
    ServerProperties serverProperties;

    @Override
    protected void configure(HttpSecurity http) throws Exception {
        http.cors().and();
        http.csrf().disable();
        http.httpBasic().disable();

        http.headers().frameOptions().sameOrigin().httpStrictTransportSecurity().disable();

        http.authorizeRequests()
                .mvcMatchers("/api/user/login").permitAll()  //Have always to be not secured!
                .anyRequest().authenticated();


        http.addFilterBefore(new JwtPreAuthTokenFilter(EXPIRATION_TIME), BasicAuthenticationFilter.class);

        if (serverProperties.getAllowedTokens()!=null && !serverProperties.getAllowedTokens().isEmpty()) {
            String[] allowedTokens=serverProperties.getAllowedTokens().split(",");
            http.addFilterBefore(new TokenBasedAuthFilter(allowedTokens), JwtPreAuthTokenFilter.class);
        }


    }




    @Override
    protected void configure(AuthenticationManagerBuilder auth) throws Exception {
        auth.authenticationProvider(tokenBasedAuthenticationProvider());
    }

    @Bean
    public TokenBasedAuthenticationProvider tokenBasedAuthenticationProvider() {
        return new TokenBasedAuthenticationProvider();
    }

    public static class TokenBasedAuthFilter extends GenericFilterBean {

        private static final String X_AUTH_TOKEN = "X-Auth-Token";
        private static final String X_AUTH_CLIENT_ID = "X-Auth-ClientId";

        public TokenBasedAuthFilter(String[] allowedTokens) {
            this.allowedTokens = new HashSet<>(allowedTokens.length);
            this.allowedTokens.addAll(Arrays.asList(allowedTokens));
        }

        HashSet<String> allowedTokens;

        @Override
        public void doFilter(ServletRequest request, ServletResponse response, FilterChain filterChain) throws
                IOException, ServletException {
            HttpServletRequest servletRequest = (HttpServletRequest) request;
            String token = servletRequest.getHeader(X_AUTH_TOKEN);
            if (token != null && allowedTokens.contains(token)) {
                final List<String> roles = Arrays.asList(UserData.Permissions.ROLE_NODE.name());
                final List<SimpleGrantedAuthority> authorities = roles.stream()
                        .map(role -> new SimpleGrantedAuthority(role))
                        .collect(Collectors.toList());
                final PreAuthenticatedAuthenticationToken authenticationToken = new PreAuthenticatedAuthenticationToken(
                        UserData.builder().userName("NODE_"+servletRequest.getHeader(X_AUTH_CLIENT_ID)).build(),
                        null,
                        authorities);
                authenticationToken.setDetails(new WebAuthenticationDetailsSource().buildDetails(servletRequest));
                SecurityContextHolder.getContext().setAuthentication(authenticationToken);
            }
            filterChain.doFilter(request, response);
        }
    }



    public static class JwtPreAuthTokenFilter extends GenericFilterBean {


        private final long allowedClockSkewSeconds;

        @Autowired
        public JwtPreAuthTokenFilter(long allowedClockSkewSeconds) {
            this.allowedClockSkewSeconds = allowedClockSkewSeconds;
        }

        @Override
        public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException,
                ServletException {
            HttpServletRequest servletRequest = (HttpServletRequest) request;
            String authorization = servletRequest.getHeader(HEADER_STRING);
            if (authorization != null && authorization.startsWith(TOKEN_PREFIX)) {
                String token = authorization.replace(TOKEN_PREFIX, "");

                UserData user = GetUserFromToken(token,allowedClockSkewSeconds);
                handleUser(servletRequest, user);
            }
            chain.doFilter(request, response);
        }

        public static String GetTokenFromUser(UserData user) {
            Date date = new Date(System.currentTimeMillis()+EXPIRATION_TIME);

            HashMap<String, Object> claims=new HashMap<>();
            claims.put("roles",user.getPermissions().stream().map(x->x.name()).toArray());
            claims.put("fullName",user.getFullName());
            claims.put("userName",user.getUserName());

            String jwt=Jwts.builder()
                    .setSubject(user.getUserName())
                    .setClaims(claims)
                    .setExpiration(date)
                    .setIssuedAt(new Date(System.currentTimeMillis()))
                    .signWith(SignatureAlgorithm.HS256, SECRET.getBytes(StandardCharsets.UTF_8))
                    .compact();
            return jwt;
        }

        public static UserData GetUserFromToken(String token,long allowedClockSkewSeconds)  {
            Claims body = Jwts.parser()
                    .setSigningKey(SECRET.getBytes(StandardCharsets.UTF_8))
                    .setAllowedClockSkewSeconds(allowedClockSkewSeconds)
                    .parseClaimsJws(token)
                    .getBody();

            //final String username = body.getSubject();
            final String username = body.get("userName").toString();
            final List<String> roles = body.get("roles", new ArrayList<String>().getClass());
            String fullName = body.get("fullName").toString();

            UserData userData=UserData.builder().userName(username).fullName(fullName).build();
            userData.setPermissions(roles.stream().map(role->UserData.Permissions.valueOf(role)).collect(Collectors.toList()));
            return userData;
        }

        private void handleUser(HttpServletRequest servletRequest, UserData user) {

            final List<SimpleGrantedAuthority> authorities = user.getPermissions().stream()
                    .map(role -> new SimpleGrantedAuthority(role.name()))
                    .collect(Collectors.toList());


            final PreAuthenticatedAuthenticationToken authenticationToken = new PreAuthenticatedAuthenticationToken(
                    user,
                    null,
                    authorities);
            authenticationToken.setDetails(new WebAuthenticationDetailsSource().buildDetails(servletRequest));
            SecurityContextHolder.getContext().setAuthentication(authenticationToken);
        }
    }

    public static class TokenBasedAuthenticationProvider implements AuthenticationProvider {

        @Override
        public Authentication authenticate(Authentication authentication) throws AuthenticationException {
            return authentication;
        }

        @Override
        public boolean supports(Class<?> aClass) {
            return PreAuthenticatedAuthenticationToken.class.isAssignableFrom(aClass);
        }
    }
}
