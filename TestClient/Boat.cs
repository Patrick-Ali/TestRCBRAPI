using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientSample
{
    public class Boat
    {
        public string Id;

        public string Beam { get; set; } // 17.3 in (440mm)

        public string BeamM { get; set; } // in 

        public string Type { get; set; } //Catamaran

        public string DriveSystem { get; set; } //Flex shaft

        public string HullHeight { get; set; } //9.5 in (241mm)

        public string HullHeightM { get; set; } // in 

        public string HullMaterial { get; set; } //Fiberglass

        public string Length { get; set; } //48 in (1245mm)

        public string LengthM { get; set; } // in 

        public string MotorSize { get; set; } //6-pole 1000Kv 56×87mm

        public string PropellerSize { get; set; } //1.4×1.90 and 1.4×2.0

        public string Radio { get; set; } //Spektrum DX2E

        public string Scale { get; set; }  //48-inch

        public string ScaleM { get; set; }  // inch

        public string Speed { get; set; } //55+ mph with 8S Li-Po

        public string SpeedM { get; set; } // mph 

        public string SpeedControl { get; set; } //Dynamite 160A HV 2S-8S

        public string Steering { get; set; } //In-line rudder with break away

        public string Coluors { get; set; } //Orange, Gray, White

        public string Weight { get; set; } //12.5 lb(7.5kg)

        public string WeightM { get; set; } // lb

        public string CaptainID { get; set; }
    }
}
