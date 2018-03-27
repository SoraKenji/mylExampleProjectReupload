using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums {
    public enum TipoDeResputa { _integer_, _string_ }
}

public class EnumFlagAttribute : PropertyAttribute
{
    public EnumFlagAttribute() { }
}
