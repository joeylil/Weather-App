using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Classes
{
    public class Rain
    {
        [JsonProperty("3h")]
        private float _rainVolumeOverPast3Hours;

        public float RainVolumeOverPast3Hours
        {
            get { return _rainVolumeOverPast3Hours; }
            set
            {
                _rainVolumeOverPast3Hours = value;
            }
        }
    }
}
