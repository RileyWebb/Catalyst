namespace Catalyst
{
    public class Version
    {
        public int Major;
        public int Minor;
        public int Patch;

        public Version(int major, int minor, int patch)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
        }
        
        public override string ToString() => $"{Major}.{Minor}.{Patch}";
    }
}