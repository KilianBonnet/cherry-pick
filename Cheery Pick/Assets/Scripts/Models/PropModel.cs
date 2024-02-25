using System;
using System.Linq;

[Serializable]
public class PropModel
{
    public PropId PropId;
    public string Name;
    public DateTime ObtainedAt;

    public PropModel(PropId propId)
    {
        PropId = propId;
        Name = string.Join(" ", PropId.ToString().Split('_').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
        ObtainedAt = DateTime.Now;
    }
}

[Serializable]
public class SerializableVector3
{

}
