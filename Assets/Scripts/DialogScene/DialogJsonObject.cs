using System;
using System.Collections.Generic;

public class DialogJsonObject
{
    [Serializable]
    class DialogNode
    {
        public string CharacterName;
        public string Content;
        public List<DialogSettingPipeline> Settings;
    }

}
