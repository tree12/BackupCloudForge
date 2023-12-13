package eatlab.dms.server.helper;

import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

public class MD5Hash {
    static public String createMD5(String str) throws NoSuchAlgorithmException {
        byte[] digiest = MessageDigest.getInstance("MD5").digest(str.getBytes(StandardCharsets.UTF_8));
        return new String(digiest,StandardCharsets.UTF_8);
    }
}
