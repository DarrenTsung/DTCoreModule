using UnityEngine;
using UnityEngine.Events;

namespace UnityEvents
{
    [System.Serializable]
    public class F : UnityEvent<float> { }

    [System.Serializable]
    public class I : UnityEvent<int> { }

    [System.Serializable]
    public class S : UnityEvent<string> { }

    [System.Serializable]
    public class B : UnityEvent<bool> { }

    [System.Serializable]
    public class V2 : UnityEvent<Vector2> { }

    [System.Serializable]
    public class V3 : UnityEvent<Vector3> { }

    [System.Serializable]
    public class O : UnityEvent<object> { }

    [System.Serializable]
    public class G : UnityEvent<GameObject> { }

    [System.Serializable]
    public class FF : UnityEvent<float, float> { }

    [System.Serializable]
    public class FI : UnityEvent<float, int> { }

    [System.Serializable]
    public class FS : UnityEvent<float, string> { }

    [System.Serializable]
    public class FB : UnityEvent<float, bool> { }

    [System.Serializable]
    public class FO : UnityEvent<float, object> { }

    [System.Serializable]
    public class IF : UnityEvent<int, float> { }

    [System.Serializable]
    public class II : UnityEvent<int, int> { }

    [System.Serializable]
    public class IS : UnityEvent<int, string> { }

    [System.Serializable]
    public class IB : UnityEvent<int, bool> { }

    [System.Serializable]
    public class IO : UnityEvent<int, object> { }

    [System.Serializable]
    public class IG : UnityEvent<int, GameObject> { }

    [System.Serializable]
    public class IV2 : UnityEvent<int, Vector2> { }

    [System.Serializable]
    public class IV3 : UnityEvent<int, Vector3> { }

    [System.Serializable]
    public class SF : UnityEvent<string, float> { }

    [System.Serializable]
    public class SI : UnityEvent<string, int> { }

    [System.Serializable]
    public class SS : UnityEvent<string, string> { }

    [System.Serializable]
    public class SB : UnityEvent<string, bool> { }

    [System.Serializable]
    public class SO : UnityEvent<string, object> { }

    [System.Serializable]
    public class BF : UnityEvent<bool, float> { }

    [System.Serializable]
    public class BI : UnityEvent<bool, int> { }

    [System.Serializable]
    public class BS : UnityEvent<bool, string> { }

    [System.Serializable]
    public class BB : UnityEvent<bool, bool> { }

    [System.Serializable]
    public class BO : UnityEvent<bool, object> { }

    [System.Serializable]
    public class OF : UnityEvent<object, float> { }

    [System.Serializable]
    public class OI : UnityEvent<object, int> { }

    [System.Serializable]
    public class OS : UnityEvent<object, string> { }

    [System.Serializable]
    public class OB : UnityEvent<object, bool> { }

    [System.Serializable]
    public class OO : UnityEvent<object, object> { }

    [System.Serializable]
    public class FFF : UnityEvent<float, float, float> { }

    [System.Serializable]
    public class FFI : UnityEvent<float, float, int> { }

    [System.Serializable]
    public class FFS : UnityEvent<float, float, string> { }

    [System.Serializable]
    public class FFB : UnityEvent<float, float, bool> { }

    [System.Serializable]
    public class FFO : UnityEvent<float, float, object> { }

    [System.Serializable]
    public class FIF : UnityEvent<float, int, float> { }

    [System.Serializable]
    public class FII : UnityEvent<float, int, int> { }

    [System.Serializable]
    public class FIS : UnityEvent<float, int, string> { }

    [System.Serializable]
    public class FIB : UnityEvent<float, int, bool> { }

    [System.Serializable]
    public class FIO : UnityEvent<float, int, object> { }

    [System.Serializable]
    public class FSF : UnityEvent<float, string, float> { }

    [System.Serializable]
    public class FSI : UnityEvent<float, string, int> { }

    [System.Serializable]
    public class FSS : UnityEvent<float, string, string> { }

    [System.Serializable]
    public class FSB : UnityEvent<float, string, bool> { }

    [System.Serializable]
    public class FSO : UnityEvent<float, string, object> { }

    [System.Serializable]
    public class FBF : UnityEvent<float, bool, float> { }

    [System.Serializable]
    public class FBI : UnityEvent<float, bool, int> { }

    [System.Serializable]
    public class FBS : UnityEvent<float, bool, string> { }

    [System.Serializable]
    public class FBB : UnityEvent<float, bool, bool> { }

    [System.Serializable]
    public class FBO : UnityEvent<float, bool, object> { }

    [System.Serializable]
    public class FOF : UnityEvent<float, object, float> { }

    [System.Serializable]
    public class FOI : UnityEvent<float, object, int> { }

    [System.Serializable]
    public class FOS : UnityEvent<float, object, string> { }

    [System.Serializable]
    public class FOB : UnityEvent<float, object, bool> { }

    [System.Serializable]
    public class FOO : UnityEvent<float, object, object> { }

    [System.Serializable]
    public class IFF : UnityEvent<int, float, float> { }

    [System.Serializable]
    public class IFI : UnityEvent<int, float, int> { }

    [System.Serializable]
    public class IFS : UnityEvent<int, float, string> { }

    [System.Serializable]
    public class IFB : UnityEvent<int, float, bool> { }

    [System.Serializable]
    public class IFO : UnityEvent<int, float, object> { }

    [System.Serializable]
    public class IIF : UnityEvent<int, int, float> { }

    [System.Serializable]
    public class III : UnityEvent<int, int, int> { }

    [System.Serializable]
    public class IIS : UnityEvent<int, int, string> { }

    [System.Serializable]
    public class IIB : UnityEvent<int, int, bool> { }

    [System.Serializable]
    public class IIO : UnityEvent<int, int, object> { }

    [System.Serializable]
    public class ISF : UnityEvent<int, string, float> { }

    [System.Serializable]
    public class ISI : UnityEvent<int, string, int> { }

    [System.Serializable]
    public class ISS : UnityEvent<int, string, string> { }

    [System.Serializable]
    public class ISB : UnityEvent<int, string, bool> { }

    [System.Serializable]
    public class ISO : UnityEvent<int, string, object> { }

    [System.Serializable]
    public class IBF : UnityEvent<int, bool, float> { }

    [System.Serializable]
    public class IBI : UnityEvent<int, bool, int> { }

    [System.Serializable]
    public class IBS : UnityEvent<int, bool, string> { }

    [System.Serializable]
    public class IBB : UnityEvent<int, bool, bool> { }

    [System.Serializable]
    public class IBO : UnityEvent<int, bool, object> { }

    [System.Serializable]
    public class IOF : UnityEvent<int, object, float> { }

    [System.Serializable]
    public class IOI : UnityEvent<int, object, int> { }

    [System.Serializable]
    public class IOS : UnityEvent<int, object, string> { }

    [System.Serializable]
    public class IOB : UnityEvent<int, object, bool> { }

    [System.Serializable]
    public class IOO : UnityEvent<int, object, object> { }

    [System.Serializable]
    public class SFF : UnityEvent<string, float, float> { }

    [System.Serializable]
    public class SFI : UnityEvent<string, float, int> { }

    [System.Serializable]
    public class SFS : UnityEvent<string, float, string> { }

    [System.Serializable]
    public class SFB : UnityEvent<string, float, bool> { }

    [System.Serializable]
    public class SFO : UnityEvent<string, float, object> { }

    [System.Serializable]
    public class SIF : UnityEvent<string, int, float> { }

    [System.Serializable]
    public class SII : UnityEvent<string, int, int> { }

    [System.Serializable]
    public class SIS : UnityEvent<string, int, string> { }

    [System.Serializable]
    public class SIB : UnityEvent<string, int, bool> { }

    [System.Serializable]
    public class SIO : UnityEvent<string, int, object> { }

    [System.Serializable]
    public class SSF : UnityEvent<string, string, float> { }

    [System.Serializable]
    public class SSI : UnityEvent<string, string, int> { }

    [System.Serializable]
    public class SSS : UnityEvent<string, string, string> { }

    [System.Serializable]
    public class SSB : UnityEvent<string, string, bool> { }

    [System.Serializable]
    public class SSO : UnityEvent<string, string, object> { }

    [System.Serializable]
    public class SBF : UnityEvent<string, bool, float> { }

    [System.Serializable]
    public class SBI : UnityEvent<string, bool, int> { }

    [System.Serializable]
    public class SBS : UnityEvent<string, bool, string> { }

    [System.Serializable]
    public class SBB : UnityEvent<string, bool, bool> { }

    [System.Serializable]
    public class SBO : UnityEvent<string, bool, object> { }

    [System.Serializable]
    public class SOF : UnityEvent<string, object, float> { }

    [System.Serializable]
    public class SOI : UnityEvent<string, object, int> { }

    [System.Serializable]
    public class SOS : UnityEvent<string, object, string> { }

    [System.Serializable]
    public class SOB : UnityEvent<string, object, bool> { }

    [System.Serializable]
    public class SOO : UnityEvent<string, object, object> { }

    [System.Serializable]
    public class BFF : UnityEvent<bool, float, float> { }

    [System.Serializable]
    public class BFI : UnityEvent<bool, float, int> { }

    [System.Serializable]
    public class BFS : UnityEvent<bool, float, string> { }

    [System.Serializable]
    public class BFB : UnityEvent<bool, float, bool> { }

    [System.Serializable]
    public class BFO : UnityEvent<bool, float, object> { }

    [System.Serializable]
    public class BIF : UnityEvent<bool, int, float> { }

    [System.Serializable]
    public class BII : UnityEvent<bool, int, int> { }

    [System.Serializable]
    public class BIS : UnityEvent<bool, int, string> { }

    [System.Serializable]
    public class BIB : UnityEvent<bool, int, bool> { }

    [System.Serializable]
    public class BIO : UnityEvent<bool, int, object> { }

    [System.Serializable]
    public class BSF : UnityEvent<bool, string, float> { }

    [System.Serializable]
    public class BSI : UnityEvent<bool, string, int> { }

    [System.Serializable]
    public class BSS : UnityEvent<bool, string, string> { }

    [System.Serializable]
    public class BSB : UnityEvent<bool, string, bool> { }

    [System.Serializable]
    public class BSO : UnityEvent<bool, string, object> { }

    [System.Serializable]
    public class BBF : UnityEvent<bool, bool, float> { }

    [System.Serializable]
    public class BBI : UnityEvent<bool, bool, int> { }

    [System.Serializable]
    public class BBS : UnityEvent<bool, bool, string> { }

    [System.Serializable]
    public class BBB : UnityEvent<bool, bool, bool> { }

    [System.Serializable]
    public class BBO : UnityEvent<bool, bool, object> { }

    [System.Serializable]
    public class BOF : UnityEvent<bool, object, float> { }

    [System.Serializable]
    public class BOI : UnityEvent<bool, object, int> { }

    [System.Serializable]
    public class BOS : UnityEvent<bool, object, string> { }

    [System.Serializable]
    public class BOB : UnityEvent<bool, object, bool> { }

    [System.Serializable]
    public class BOO : UnityEvent<bool, object, object> { }

    [System.Serializable]
    public class OFF : UnityEvent<object, float, float> { }

    [System.Serializable]
    public class OFI : UnityEvent<object, float, int> { }

    [System.Serializable]
    public class OFS : UnityEvent<object, float, string> { }

    [System.Serializable]
    public class OFB : UnityEvent<object, float, bool> { }

    [System.Serializable]
    public class OFO : UnityEvent<object, float, object> { }

    [System.Serializable]
    public class OIF : UnityEvent<object, int, float> { }

    [System.Serializable]
    public class OII : UnityEvent<object, int, int> { }

    [System.Serializable]
    public class OIS : UnityEvent<object, int, string> { }

    [System.Serializable]
    public class OIB : UnityEvent<object, int, bool> { }

    [System.Serializable]
    public class OIO : UnityEvent<object, int, object> { }

    [System.Serializable]
    public class OSF : UnityEvent<object, string, float> { }

    [System.Serializable]
    public class OSI : UnityEvent<object, string, int> { }

    [System.Serializable]
    public class OSS : UnityEvent<object, string, string> { }

    [System.Serializable]
    public class OSB : UnityEvent<object, string, bool> { }

    [System.Serializable]
    public class OSO : UnityEvent<object, string, object> { }

    [System.Serializable]
    public class OBF : UnityEvent<object, bool, float> { }

    [System.Serializable]
    public class OBI : UnityEvent<object, bool, int> { }

    [System.Serializable]
    public class OBS : UnityEvent<object, bool, string> { }

    [System.Serializable]
    public class OBB : UnityEvent<object, bool, bool> { }

    [System.Serializable]
    public class OBO : UnityEvent<object, bool, object> { }

    [System.Serializable]
    public class OOF : UnityEvent<object, object, float> { }

    [System.Serializable]
    public class OOI : UnityEvent<object, object, int> { }

    [System.Serializable]
    public class OOS : UnityEvent<object, object, string> { }

    [System.Serializable]
    public class OOB : UnityEvent<object, object, bool> { }

    [System.Serializable]
    public class OOO : UnityEvent<object, object, object> { }
}