using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;

namespace ATom.CommonBasics.Extension
{
    public static class StreamExtension
    {
 
        public static byte[] LoadToMemory(this Stream sourceStream) {
            byte[] buffer = new byte[sourceStream.Length];
            MemoryStream memStream = new MemoryStream(buffer);
            sourceStream.CopyTo(memStream);
            return buffer;
        }

        public static int ReadExact(this Stream stream, byte[] data, int count,byte[] shadowBuffer=null,int timeout=-1) {
            if (shadowBuffer==null) shadowBuffer=new byte[data.Length];
            int i = 0;
            int readcount = 0;
            long lastReadWithData = DateTime.Now.Ticks;
            do {
                readcount = stream.Read(shadowBuffer, 0, count - i);
                if (readcount > 0) {
                    Array.Copy(shadowBuffer, 0, data, i, readcount);
                    lastReadWithData = DateTime.Now.Ticks;
                    if (readcount < count) Thread.Sleep(50);
                } else {
                    if (timeout>0 && lastReadWithData+timeout<DateTime.Now.Ticks) throw new IOException("Keine Daten innerhalb des Timeouts empfangen.");
                    Thread.Sleep(100);
                }
                i += readcount;
            } while (i<count);                                         
            return i;
        }

        public static void CopyExact(this Stream inStream, long count, Stream outStream,int timeOut=-1)
        {
            long i = 0;
            int bufferSize = 50000;
            byte[] buffer = new byte[bufferSize];
            byte[] shadowBuffer = new byte[bufferSize];
            do {
                int nextReadSize = (int) Math.Min(count-i, bufferSize);
                int readActual = inStream.ReadExact(buffer, nextReadSize,shadowBuffer,timeOut);                
                outStream.Write(buffer, 0, readActual);
                i += readActual;
            } while (i < count);
        }

        public static int ReadByteExact(this Stream stream,int timeout=-1)
        {
            int b = -1;
            long lastReadWithData = DateTime.Now.Ticks;
            while (0 > (b = stream.ReadByte()))
            {
                if (timeout > 0 && lastReadWithData + timeout < DateTime.Now.Ticks) throw new IOException("Keine Daten innerhalb des Timeouts empfangen.");
                Thread.Sleep(50);
            }
            return b;
        }
    }
}
