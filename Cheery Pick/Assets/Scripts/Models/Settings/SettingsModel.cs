[System.Serializable]
public class SettingsModel
{
    public LangEnum Language;
    public bool AutoSave;

    public SettingsModel()
    {
        Language = LangEnum.ENGLISH;
        AutoSave = true;
    }

    public SettingsModel(LangEnum language, bool autoSave)
    {
        Language = language;
        AutoSave = autoSave;
    }
}
