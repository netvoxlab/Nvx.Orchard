namespace Nvx.Fields.MapInfrastructure {
    public interface IGeocode {
        Location GetLocation(string adress);
        string GetMapUrl(int h, int w,Location point);
        string MakeMap(string controlid);
        string AddPoint(string controlid, double lat, double lng, string label);
    }
}