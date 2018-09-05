using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace DashHashWrapper
{
    public sealed class DashHashWrapper
    {
        [DllImport(@"DashHash.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DashHash(IntPtr input, int len, IntPtr output);

        public byte[] CalcDashHash(string inputDataHexString)
        {
            byte[] inputData = StringToByteArray(inputDataHexString);
            return CalcDashHash(inputData);
        }

        public byte[] CalcDashHash(byte[] inputData)
        {
            byte[] outputData = new byte[32];
            int size = Marshal.SizeOf(outputData[0]) * outputData.Length;

            IntPtr pointerOutput = Marshal.AllocHGlobal(size);
            GCHandle pinnedArray = GCHandle.Alloc(inputData, GCHandleType.Pinned);
            IntPtr pointerToInputData = pinnedArray.AddrOfPinnedObject();

            try
            {
                Marshal.Copy(outputData, 0, pointerOutput, outputData.Length);



                DashHash(pointerToInputData, inputData.Length, pointerOutput);

                Marshal.Copy(pointerOutput, outputData, 0, outputData.Length);
            }
            finally
            {
                Marshal.FreeHGlobal(pointerOutput);
            }

            return outputData;
        }

        public byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public string ByteArrayToString(byte[] array)
        {
            return string.Join(string.Empty, array.Select(hex => hex.ToString("X2")));
        }
    }
}
