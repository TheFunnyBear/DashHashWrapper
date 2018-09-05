using NUnit.Framework;

namespace DashHashWrapper.Tests
{
    [TestFixture]
    public class DashHashWrapperTests
    {
        public string BestHashString => "434341c0ecf9a2b4eec2644cfadf4d0a07830358aed12d0ed654121dd9070000";
    

        [Test]
        public void CheckDashHashFromString()
        {
            var dashHashWrapper = new DashHashWrapper();

            var headerHexString = "02000000" +
                "b67a40f3cd5804437a108f105533739c37e6229bc1adcab385140b59fd0f0000" +
                "a71c1aade44bf8425bec0deb611c20b16da3442818ef20489ca1e2512be43eef" +
                "814cdb52" +
                "f0ff0f1e" +
                "dbf70100";

            var hash = dashHashWrapper.CalcDashHash(headerHexString);
            var hashString = dashHashWrapper.ByteArrayToString(hash);
            Assert.AreEqual(BestHashString.ToUpper(), hashString, "Not expected Hash calculated.");
        }

        [Test]
        public void CheckDashHashFromArray()
        {
            var dashHashWrapper = new DashHashWrapper();

            byte[] headerHex = new byte[] {
                0x02,
                0x00,
                0x00,
                0x00,
                0xb6,
                0x7a,
                0x40,
                0xf3,
                0xcd,
                0x58,
                0x04,
                0x43,
                0x7a,
                0x10,
                0x8f,
                0x10,
                0x55,
                0x33,
                0x73,
                0x9c,
                0x37,
                0xe6,
                0x22,
                0x9b,
                0xc1,
                0xad,
                0xca,
                0xb3,
                0x85,
                0x14,
                0x0b,
                0x59,
                0xfd,
                0x0f,
                0x00,
                0x00,
                0xa7,
                0x1c,
                0x1a,
                0xad,
                0xe4,
                0x4b,
                0xf8,
                0x42,
                0x5b,
                0xec,
                0x0d,
                0xeb,
                0x61,
                0x1c,
                0x20,
                0xb1,
                0x6d,
                0xa3,
                0x44,
                0x28,
                0x18,
                0xef,
                0x20,
                0x48,
                0x9c,
                0xa1,
                0xe2,
                0x51,
                0x2b,
                0xe4,
                0x3e,
                0xef,
                0x81,
                0x4c,
                0xdb,
                0x52,
                0xf0,
                0xff,
                0x0f,
                0x1e,
                0xdb,
                0xf7,
                0x01,
                0x00
            };

            var hash = dashHashWrapper.CalcDashHash(headerHex);
            var hashString = dashHashWrapper.ByteArrayToString(hash);
            Assert.AreEqual(BestHashString.ToUpper(), hashString, "Not expected Hash calculated.");
        }
    }
}
