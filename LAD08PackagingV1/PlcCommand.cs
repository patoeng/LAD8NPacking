using ModbusTCP;

namespace LAD08PackagingV1
{
    public class PlcCommand
    {
        public static bool GetPlcRawData(Master master, ushort number, ref byte[] data)
        {
            try
            {
                master.ReadHoldingRegister(1, 1, 20, number, ref data);

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
