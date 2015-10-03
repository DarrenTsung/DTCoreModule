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

    [System.Serializable]
    public class FFFF : UnityEvent<float, float, float, float> { }

    [System.Serializable]
    public class FFFI : UnityEvent<float, float, float, int> { }

    [System.Serializable]
    public class FFFS : UnityEvent<float, float, float, string> { }

    [System.Serializable]
    public class FFFB : UnityEvent<float, float, float, bool> { }

    [System.Serializable]
    public class FFFO : UnityEvent<float, float, float, object> { }

    [System.Serializable]
    public class FFIF : UnityEvent<float, float, int, float> { }

    [System.Serializable]
    public class FFII : UnityEvent<float, float, int, int> { }

    [System.Serializable]
    public class FFIS : UnityEvent<float, float, int, string> { }

    [System.Serializable]
    public class FFIB : UnityEvent<float, float, int, bool> { }

    [System.Serializable]
    public class FFIO : UnityEvent<float, float, int, object> { }

    [System.Serializable]
    public class FFSF : UnityEvent<float, float, string, float> { }

    [System.Serializable]
    public class FFSI : UnityEvent<float, float, string, int> { }

    [System.Serializable]
    public class FFSS : UnityEvent<float, float, string, string> { }

    [System.Serializable]
    public class FFSB : UnityEvent<float, float, string, bool> { }

    [System.Serializable]
    public class FFSO : UnityEvent<float, float, string, object> { }

    [System.Serializable]
    public class FFBF : UnityEvent<float, float, bool, float> { }

    [System.Serializable]
    public class FFBI : UnityEvent<float, float, bool, int> { }

    [System.Serializable]
    public class FFBS : UnityEvent<float, float, bool, string> { }

    [System.Serializable]
    public class FFBB : UnityEvent<float, float, bool, bool> { }

    [System.Serializable]
    public class FFBO : UnityEvent<float, float, bool, object> { }

    [System.Serializable]
    public class FFOF : UnityEvent<float, float, object, float> { }

    [System.Serializable]
    public class FFOI : UnityEvent<float, float, object, int> { }

    [System.Serializable]
    public class FFOS : UnityEvent<float, float, object, string> { }

    [System.Serializable]
    public class FFOB : UnityEvent<float, float, object, bool> { }

    [System.Serializable]
    public class FFOO : UnityEvent<float, float, object, object> { }

    [System.Serializable]
    public class FIFF : UnityEvent<float, int, float, float> { }

    [System.Serializable]
    public class FIFI : UnityEvent<float, int, float, int> { }

    [System.Serializable]
    public class FIFS : UnityEvent<float, int, float, string> { }

    [System.Serializable]
    public class FIFB : UnityEvent<float, int, float, bool> { }

    [System.Serializable]
    public class FIFO : UnityEvent<float, int, float, object> { }

    [System.Serializable]
    public class FIIF : UnityEvent<float, int, int, float> { }

    [System.Serializable]
    public class FIII : UnityEvent<float, int, int, int> { }

    [System.Serializable]
    public class FIIS : UnityEvent<float, int, int, string> { }

    [System.Serializable]
    public class FIIB : UnityEvent<float, int, int, bool> { }

    [System.Serializable]
    public class FIIO : UnityEvent<float, int, int, object> { }

    [System.Serializable]
    public class FISF : UnityEvent<float, int, string, float> { }

    [System.Serializable]
    public class FISI : UnityEvent<float, int, string, int> { }

    [System.Serializable]
    public class FISS : UnityEvent<float, int, string, string> { }

    [System.Serializable]
    public class FISB : UnityEvent<float, int, string, bool> { }

    [System.Serializable]
    public class FISO : UnityEvent<float, int, string, object> { }

    [System.Serializable]
    public class FIBF : UnityEvent<float, int, bool, float> { }

    [System.Serializable]
    public class FIBI : UnityEvent<float, int, bool, int> { }

    [System.Serializable]
    public class FIBS : UnityEvent<float, int, bool, string> { }

    [System.Serializable]
    public class FIBB : UnityEvent<float, int, bool, bool> { }

    [System.Serializable]
    public class FIBO : UnityEvent<float, int, bool, object> { }

    [System.Serializable]
    public class FIOF : UnityEvent<float, int, object, float> { }

    [System.Serializable]
    public class FIOI : UnityEvent<float, int, object, int> { }

    [System.Serializable]
    public class FIOS : UnityEvent<float, int, object, string> { }

    [System.Serializable]
    public class FIOB : UnityEvent<float, int, object, bool> { }

    [System.Serializable]
    public class FIOO : UnityEvent<float, int, object, object> { }

    [System.Serializable]
    public class FSFF : UnityEvent<float, string, float, float> { }

    [System.Serializable]
    public class FSFI : UnityEvent<float, string, float, int> { }

    [System.Serializable]
    public class FSFS : UnityEvent<float, string, float, string> { }

    [System.Serializable]
    public class FSFB : UnityEvent<float, string, float, bool> { }

    [System.Serializable]
    public class FSFO : UnityEvent<float, string, float, object> { }

    [System.Serializable]
    public class FSIF : UnityEvent<float, string, int, float> { }

    [System.Serializable]
    public class FSII : UnityEvent<float, string, int, int> { }

    [System.Serializable]
    public class FSIS : UnityEvent<float, string, int, string> { }

    [System.Serializable]
    public class FSIB : UnityEvent<float, string, int, bool> { }

    [System.Serializable]
    public class FSIO : UnityEvent<float, string, int, object> { }

    [System.Serializable]
    public class FSSF : UnityEvent<float, string, string, float> { }

    [System.Serializable]
    public class FSSI : UnityEvent<float, string, string, int> { }

    [System.Serializable]
    public class FSSS : UnityEvent<float, string, string, string> { }

    [System.Serializable]
    public class FSSB : UnityEvent<float, string, string, bool> { }

    [System.Serializable]
    public class FSSO : UnityEvent<float, string, string, object> { }

    [System.Serializable]
    public class FSBF : UnityEvent<float, string, bool, float> { }

    [System.Serializable]
    public class FSBI : UnityEvent<float, string, bool, int> { }

    [System.Serializable]
    public class FSBS : UnityEvent<float, string, bool, string> { }

    [System.Serializable]
    public class FSBB : UnityEvent<float, string, bool, bool> { }

    [System.Serializable]
    public class FSBO : UnityEvent<float, string, bool, object> { }

    [System.Serializable]
    public class FSOF : UnityEvent<float, string, object, float> { }

    [System.Serializable]
    public class FSOI : UnityEvent<float, string, object, int> { }

    [System.Serializable]
    public class FSOS : UnityEvent<float, string, object, string> { }

    [System.Serializable]
    public class FSOB : UnityEvent<float, string, object, bool> { }

    [System.Serializable]
    public class FSOO : UnityEvent<float, string, object, object> { }

    [System.Serializable]
    public class FBFF : UnityEvent<float, bool, float, float> { }

    [System.Serializable]
    public class FBFI : UnityEvent<float, bool, float, int> { }

    [System.Serializable]
    public class FBFS : UnityEvent<float, bool, float, string> { }

    [System.Serializable]
    public class FBFB : UnityEvent<float, bool, float, bool> { }

    [System.Serializable]
    public class FBFO : UnityEvent<float, bool, float, object> { }

    [System.Serializable]
    public class FBIF : UnityEvent<float, bool, int, float> { }

    [System.Serializable]
    public class FBII : UnityEvent<float, bool, int, int> { }

    [System.Serializable]
    public class FBIS : UnityEvent<float, bool, int, string> { }

    [System.Serializable]
    public class FBIB : UnityEvent<float, bool, int, bool> { }

    [System.Serializable]
    public class FBIO : UnityEvent<float, bool, int, object> { }

    [System.Serializable]
    public class FBSF : UnityEvent<float, bool, string, float> { }

    [System.Serializable]
    public class FBSI : UnityEvent<float, bool, string, int> { }

    [System.Serializable]
    public class FBSS : UnityEvent<float, bool, string, string> { }

    [System.Serializable]
    public class FBSB : UnityEvent<float, bool, string, bool> { }

    [System.Serializable]
    public class FBSO : UnityEvent<float, bool, string, object> { }

    [System.Serializable]
    public class FBBF : UnityEvent<float, bool, bool, float> { }

    [System.Serializable]
    public class FBBI : UnityEvent<float, bool, bool, int> { }

    [System.Serializable]
    public class FBBS : UnityEvent<float, bool, bool, string> { }

    [System.Serializable]
    public class FBBB : UnityEvent<float, bool, bool, bool> { }

    [System.Serializable]
    public class FBBO : UnityEvent<float, bool, bool, object> { }

    [System.Serializable]
    public class FBOF : UnityEvent<float, bool, object, float> { }

    [System.Serializable]
    public class FBOI : UnityEvent<float, bool, object, int> { }

    [System.Serializable]
    public class FBOS : UnityEvent<float, bool, object, string> { }

    [System.Serializable]
    public class FBOB : UnityEvent<float, bool, object, bool> { }

    [System.Serializable]
    public class FBOO : UnityEvent<float, bool, object, object> { }

    [System.Serializable]
    public class FOFF : UnityEvent<float, object, float, float> { }

    [System.Serializable]
    public class FOFI : UnityEvent<float, object, float, int> { }

    [System.Serializable]
    public class FOFS : UnityEvent<float, object, float, string> { }

    [System.Serializable]
    public class FOFB : UnityEvent<float, object, float, bool> { }

    [System.Serializable]
    public class FOFO : UnityEvent<float, object, float, object> { }

    [System.Serializable]
    public class FOIF : UnityEvent<float, object, int, float> { }

    [System.Serializable]
    public class FOII : UnityEvent<float, object, int, int> { }

    [System.Serializable]
    public class FOIS : UnityEvent<float, object, int, string> { }

    [System.Serializable]
    public class FOIB : UnityEvent<float, object, int, bool> { }

    [System.Serializable]
    public class FOIO : UnityEvent<float, object, int, object> { }

    [System.Serializable]
    public class FOSF : UnityEvent<float, object, string, float> { }

    [System.Serializable]
    public class FOSI : UnityEvent<float, object, string, int> { }

    [System.Serializable]
    public class FOSS : UnityEvent<float, object, string, string> { }

    [System.Serializable]
    public class FOSB : UnityEvent<float, object, string, bool> { }

    [System.Serializable]
    public class FOSO : UnityEvent<float, object, string, object> { }

    [System.Serializable]
    public class FOBF : UnityEvent<float, object, bool, float> { }

    [System.Serializable]
    public class FOBI : UnityEvent<float, object, bool, int> { }

    [System.Serializable]
    public class FOBS : UnityEvent<float, object, bool, string> { }

    [System.Serializable]
    public class FOBB : UnityEvent<float, object, bool, bool> { }

    [System.Serializable]
    public class FOBO : UnityEvent<float, object, bool, object> { }

    [System.Serializable]
    public class FOOF : UnityEvent<float, object, object, float> { }

    [System.Serializable]
    public class FOOI : UnityEvent<float, object, object, int> { }

    [System.Serializable]
    public class FOOS : UnityEvent<float, object, object, string> { }

    [System.Serializable]
    public class FOOB : UnityEvent<float, object, object, bool> { }

    [System.Serializable]
    public class FOOO : UnityEvent<float, object, object, object> { }

    [System.Serializable]
    public class IFFF : UnityEvent<int, float, float, float> { }

    [System.Serializable]
    public class IFFI : UnityEvent<int, float, float, int> { }

    [System.Serializable]
    public class IFFS : UnityEvent<int, float, float, string> { }

    [System.Serializable]
    public class IFFB : UnityEvent<int, float, float, bool> { }

    [System.Serializable]
    public class IFFO : UnityEvent<int, float, float, object> { }

    [System.Serializable]
    public class IFIF : UnityEvent<int, float, int, float> { }

    [System.Serializable]
    public class IFII : UnityEvent<int, float, int, int> { }

    [System.Serializable]
    public class IFIS : UnityEvent<int, float, int, string> { }

    [System.Serializable]
    public class IFIB : UnityEvent<int, float, int, bool> { }

    [System.Serializable]
    public class IFIO : UnityEvent<int, float, int, object> { }

    [System.Serializable]
    public class IFSF : UnityEvent<int, float, string, float> { }

    [System.Serializable]
    public class IFSI : UnityEvent<int, float, string, int> { }

    [System.Serializable]
    public class IFSS : UnityEvent<int, float, string, string> { }

    [System.Serializable]
    public class IFSB : UnityEvent<int, float, string, bool> { }

    [System.Serializable]
    public class IFSO : UnityEvent<int, float, string, object> { }

    [System.Serializable]
    public class IFBF : UnityEvent<int, float, bool, float> { }

    [System.Serializable]
    public class IFBI : UnityEvent<int, float, bool, int> { }

    [System.Serializable]
    public class IFBS : UnityEvent<int, float, bool, string> { }

    [System.Serializable]
    public class IFBB : UnityEvent<int, float, bool, bool> { }

    [System.Serializable]
    public class IFBO : UnityEvent<int, float, bool, object> { }

    [System.Serializable]
    public class IFOF : UnityEvent<int, float, object, float> { }

    [System.Serializable]
    public class IFOI : UnityEvent<int, float, object, int> { }

    [System.Serializable]
    public class IFOS : UnityEvent<int, float, object, string> { }

    [System.Serializable]
    public class IFOB : UnityEvent<int, float, object, bool> { }

    [System.Serializable]
    public class IFOO : UnityEvent<int, float, object, object> { }

    [System.Serializable]
    public class IIFF : UnityEvent<int, int, float, float> { }

    [System.Serializable]
    public class IIFI : UnityEvent<int, int, float, int> { }

    [System.Serializable]
    public class IIFS : UnityEvent<int, int, float, string> { }

    [System.Serializable]
    public class IIFB : UnityEvent<int, int, float, bool> { }

    [System.Serializable]
    public class IIFO : UnityEvent<int, int, float, object> { }

    [System.Serializable]
    public class IIIF : UnityEvent<int, int, int, float> { }

    [System.Serializable]
    public class IIII : UnityEvent<int, int, int, int> { }

    [System.Serializable]
    public class IIIS : UnityEvent<int, int, int, string> { }

    [System.Serializable]
    public class IIIB : UnityEvent<int, int, int, bool> { }

    [System.Serializable]
    public class IIIO : UnityEvent<int, int, int, object> { }

    [System.Serializable]
    public class IISF : UnityEvent<int, int, string, float> { }

    [System.Serializable]
    public class IISI : UnityEvent<int, int, string, int> { }

    [System.Serializable]
    public class IISS : UnityEvent<int, int, string, string> { }

    [System.Serializable]
    public class IISB : UnityEvent<int, int, string, bool> { }

    [System.Serializable]
    public class IISO : UnityEvent<int, int, string, object> { }

    [System.Serializable]
    public class IIBF : UnityEvent<int, int, bool, float> { }

    [System.Serializable]
    public class IIBI : UnityEvent<int, int, bool, int> { }

    [System.Serializable]
    public class IIBS : UnityEvent<int, int, bool, string> { }

    [System.Serializable]
    public class IIBB : UnityEvent<int, int, bool, bool> { }

    [System.Serializable]
    public class IIBO : UnityEvent<int, int, bool, object> { }

    [System.Serializable]
    public class IIOF : UnityEvent<int, int, object, float> { }

    [System.Serializable]
    public class IIOI : UnityEvent<int, int, object, int> { }

    [System.Serializable]
    public class IIOS : UnityEvent<int, int, object, string> { }

    [System.Serializable]
    public class IIOB : UnityEvent<int, int, object, bool> { }

    [System.Serializable]
    public class IIOO : UnityEvent<int, int, object, object> { }

    [System.Serializable]
    public class ISFF : UnityEvent<int, string, float, float> { }

    [System.Serializable]
    public class ISFI : UnityEvent<int, string, float, int> { }

    [System.Serializable]
    public class ISFS : UnityEvent<int, string, float, string> { }

    [System.Serializable]
    public class ISFB : UnityEvent<int, string, float, bool> { }

    [System.Serializable]
    public class ISFO : UnityEvent<int, string, float, object> { }

    [System.Serializable]
    public class ISIF : UnityEvent<int, string, int, float> { }

    [System.Serializable]
    public class ISII : UnityEvent<int, string, int, int> { }

    [System.Serializable]
    public class ISIS : UnityEvent<int, string, int, string> { }

    [System.Serializable]
    public class ISIB : UnityEvent<int, string, int, bool> { }

    [System.Serializable]
    public class ISIO : UnityEvent<int, string, int, object> { }

    [System.Serializable]
    public class ISSF : UnityEvent<int, string, string, float> { }

    [System.Serializable]
    public class ISSI : UnityEvent<int, string, string, int> { }

    [System.Serializable]
    public class ISSS : UnityEvent<int, string, string, string> { }

    [System.Serializable]
    public class ISSB : UnityEvent<int, string, string, bool> { }

    [System.Serializable]
    public class ISSO : UnityEvent<int, string, string, object> { }

    [System.Serializable]
    public class ISBF : UnityEvent<int, string, bool, float> { }

    [System.Serializable]
    public class ISBI : UnityEvent<int, string, bool, int> { }

    [System.Serializable]
    public class ISBS : UnityEvent<int, string, bool, string> { }

    [System.Serializable]
    public class ISBB : UnityEvent<int, string, bool, bool> { }

    [System.Serializable]
    public class ISBO : UnityEvent<int, string, bool, object> { }

    [System.Serializable]
    public class ISOF : UnityEvent<int, string, object, float> { }

    [System.Serializable]
    public class ISOI : UnityEvent<int, string, object, int> { }

    [System.Serializable]
    public class ISOS : UnityEvent<int, string, object, string> { }

    [System.Serializable]
    public class ISOB : UnityEvent<int, string, object, bool> { }

    [System.Serializable]
    public class ISOO : UnityEvent<int, string, object, object> { }

    [System.Serializable]
    public class IBFF : UnityEvent<int, bool, float, float> { }

    [System.Serializable]
    public class IBFI : UnityEvent<int, bool, float, int> { }

    [System.Serializable]
    public class IBFS : UnityEvent<int, bool, float, string> { }

    [System.Serializable]
    public class IBFB : UnityEvent<int, bool, float, bool> { }

    [System.Serializable]
    public class IBFO : UnityEvent<int, bool, float, object> { }

    [System.Serializable]
    public class IBIF : UnityEvent<int, bool, int, float> { }

    [System.Serializable]
    public class IBII : UnityEvent<int, bool, int, int> { }

    [System.Serializable]
    public class IBIS : UnityEvent<int, bool, int, string> { }

    [System.Serializable]
    public class IBIB : UnityEvent<int, bool, int, bool> { }

    [System.Serializable]
    public class IBIO : UnityEvent<int, bool, int, object> { }

    [System.Serializable]
    public class IBSF : UnityEvent<int, bool, string, float> { }

    [System.Serializable]
    public class IBSI : UnityEvent<int, bool, string, int> { }

    [System.Serializable]
    public class IBSS : UnityEvent<int, bool, string, string> { }

    [System.Serializable]
    public class IBSB : UnityEvent<int, bool, string, bool> { }

    [System.Serializable]
    public class IBSO : UnityEvent<int, bool, string, object> { }

    [System.Serializable]
    public class IBBF : UnityEvent<int, bool, bool, float> { }

    [System.Serializable]
    public class IBBI : UnityEvent<int, bool, bool, int> { }

    [System.Serializable]
    public class IBBS : UnityEvent<int, bool, bool, string> { }

    [System.Serializable]
    public class IBBB : UnityEvent<int, bool, bool, bool> { }

    [System.Serializable]
    public class IBBO : UnityEvent<int, bool, bool, object> { }

    [System.Serializable]
    public class IBOF : UnityEvent<int, bool, object, float> { }

    [System.Serializable]
    public class IBOI : UnityEvent<int, bool, object, int> { }

    [System.Serializable]
    public class IBOS : UnityEvent<int, bool, object, string> { }

    [System.Serializable]
    public class IBOB : UnityEvent<int, bool, object, bool> { }

    [System.Serializable]
    public class IBOO : UnityEvent<int, bool, object, object> { }

    [System.Serializable]
    public class IOFF : UnityEvent<int, object, float, float> { }

    [System.Serializable]
    public class IOFI : UnityEvent<int, object, float, int> { }

    [System.Serializable]
    public class IOFS : UnityEvent<int, object, float, string> { }

    [System.Serializable]
    public class IOFB : UnityEvent<int, object, float, bool> { }

    [System.Serializable]
    public class IOFO : UnityEvent<int, object, float, object> { }

    [System.Serializable]
    public class IOIF : UnityEvent<int, object, int, float> { }

    [System.Serializable]
    public class IOII : UnityEvent<int, object, int, int> { }

    [System.Serializable]
    public class IOIS : UnityEvent<int, object, int, string> { }

    [System.Serializable]
    public class IOIB : UnityEvent<int, object, int, bool> { }

    [System.Serializable]
    public class IOIO : UnityEvent<int, object, int, object> { }

    [System.Serializable]
    public class IOSF : UnityEvent<int, object, string, float> { }

    [System.Serializable]
    public class IOSI : UnityEvent<int, object, string, int> { }

    [System.Serializable]
    public class IOSS : UnityEvent<int, object, string, string> { }

    [System.Serializable]
    public class IOSB : UnityEvent<int, object, string, bool> { }

    [System.Serializable]
    public class IOSO : UnityEvent<int, object, string, object> { }

    [System.Serializable]
    public class IOBF : UnityEvent<int, object, bool, float> { }

    [System.Serializable]
    public class IOBI : UnityEvent<int, object, bool, int> { }

    [System.Serializable]
    public class IOBS : UnityEvent<int, object, bool, string> { }

    [System.Serializable]
    public class IOBB : UnityEvent<int, object, bool, bool> { }

    [System.Serializable]
    public class IOBO : UnityEvent<int, object, bool, object> { }

    [System.Serializable]
    public class IOOF : UnityEvent<int, object, object, float> { }

    [System.Serializable]
    public class IOOI : UnityEvent<int, object, object, int> { }

    [System.Serializable]
    public class IOOS : UnityEvent<int, object, object, string> { }

    [System.Serializable]
    public class IOOB : UnityEvent<int, object, object, bool> { }

    [System.Serializable]
    public class IOOO : UnityEvent<int, object, object, object> { }

    [System.Serializable]
    public class SFFF : UnityEvent<string, float, float, float> { }

    [System.Serializable]
    public class SFFI : UnityEvent<string, float, float, int> { }

    [System.Serializable]
    public class SFFS : UnityEvent<string, float, float, string> { }

    [System.Serializable]
    public class SFFB : UnityEvent<string, float, float, bool> { }

    [System.Serializable]
    public class SFFO : UnityEvent<string, float, float, object> { }

    [System.Serializable]
    public class SFIF : UnityEvent<string, float, int, float> { }

    [System.Serializable]
    public class SFII : UnityEvent<string, float, int, int> { }

    [System.Serializable]
    public class SFIS : UnityEvent<string, float, int, string> { }

    [System.Serializable]
    public class SFIB : UnityEvent<string, float, int, bool> { }

    [System.Serializable]
    public class SFIO : UnityEvent<string, float, int, object> { }

    [System.Serializable]
    public class SFSF : UnityEvent<string, float, string, float> { }

    [System.Serializable]
    public class SFSI : UnityEvent<string, float, string, int> { }

    [System.Serializable]
    public class SFSS : UnityEvent<string, float, string, string> { }

    [System.Serializable]
    public class SFSB : UnityEvent<string, float, string, bool> { }

    [System.Serializable]
    public class SFSO : UnityEvent<string, float, string, object> { }

    [System.Serializable]
    public class SFBF : UnityEvent<string, float, bool, float> { }

    [System.Serializable]
    public class SFBI : UnityEvent<string, float, bool, int> { }

    [System.Serializable]
    public class SFBS : UnityEvent<string, float, bool, string> { }

    [System.Serializable]
    public class SFBB : UnityEvent<string, float, bool, bool> { }

    [System.Serializable]
    public class SFBO : UnityEvent<string, float, bool, object> { }

    [System.Serializable]
    public class SFOF : UnityEvent<string, float, object, float> { }

    [System.Serializable]
    public class SFOI : UnityEvent<string, float, object, int> { }

    [System.Serializable]
    public class SFOS : UnityEvent<string, float, object, string> { }

    [System.Serializable]
    public class SFOB : UnityEvent<string, float, object, bool> { }

    [System.Serializable]
    public class SFOO : UnityEvent<string, float, object, object> { }

    [System.Serializable]
    public class SIFF : UnityEvent<string, int, float, float> { }

    [System.Serializable]
    public class SIFI : UnityEvent<string, int, float, int> { }

    [System.Serializable]
    public class SIFS : UnityEvent<string, int, float, string> { }

    [System.Serializable]
    public class SIFB : UnityEvent<string, int, float, bool> { }

    [System.Serializable]
    public class SIFO : UnityEvent<string, int, float, object> { }

    [System.Serializable]
    public class SIIF : UnityEvent<string, int, int, float> { }

    [System.Serializable]
    public class SIII : UnityEvent<string, int, int, int> { }

    [System.Serializable]
    public class SIIS : UnityEvent<string, int, int, string> { }

    [System.Serializable]
    public class SIIB : UnityEvent<string, int, int, bool> { }

    [System.Serializable]
    public class SIIO : UnityEvent<string, int, int, object> { }

    [System.Serializable]
    public class SISF : UnityEvent<string, int, string, float> { }

    [System.Serializable]
    public class SISI : UnityEvent<string, int, string, int> { }

    [System.Serializable]
    public class SISS : UnityEvent<string, int, string, string> { }

    [System.Serializable]
    public class SISB : UnityEvent<string, int, string, bool> { }

    [System.Serializable]
    public class SISO : UnityEvent<string, int, string, object> { }

    [System.Serializable]
    public class SIBF : UnityEvent<string, int, bool, float> { }

    [System.Serializable]
    public class SIBI : UnityEvent<string, int, bool, int> { }

    [System.Serializable]
    public class SIBS : UnityEvent<string, int, bool, string> { }

    [System.Serializable]
    public class SIBB : UnityEvent<string, int, bool, bool> { }

    [System.Serializable]
    public class SIBO : UnityEvent<string, int, bool, object> { }

    [System.Serializable]
    public class SIOF : UnityEvent<string, int, object, float> { }

    [System.Serializable]
    public class SIOI : UnityEvent<string, int, object, int> { }

    [System.Serializable]
    public class SIOS : UnityEvent<string, int, object, string> { }

    [System.Serializable]
    public class SIOB : UnityEvent<string, int, object, bool> { }

    [System.Serializable]
    public class SIOO : UnityEvent<string, int, object, object> { }

    [System.Serializable]
    public class SSFF : UnityEvent<string, string, float, float> { }

    [System.Serializable]
    public class SSFI : UnityEvent<string, string, float, int> { }

    [System.Serializable]
    public class SSFS : UnityEvent<string, string, float, string> { }

    [System.Serializable]
    public class SSFB : UnityEvent<string, string, float, bool> { }

    [System.Serializable]
    public class SSFO : UnityEvent<string, string, float, object> { }

    [System.Serializable]
    public class SSIF : UnityEvent<string, string, int, float> { }

    [System.Serializable]
    public class SSII : UnityEvent<string, string, int, int> { }

    [System.Serializable]
    public class SSIS : UnityEvent<string, string, int, string> { }

    [System.Serializable]
    public class SSIB : UnityEvent<string, string, int, bool> { }

    [System.Serializable]
    public class SSIO : UnityEvent<string, string, int, object> { }

    [System.Serializable]
    public class SSSF : UnityEvent<string, string, string, float> { }

    [System.Serializable]
    public class SSSI : UnityEvent<string, string, string, int> { }

    [System.Serializable]
    public class SSSS : UnityEvent<string, string, string, string> { }

    [System.Serializable]
    public class SSSB : UnityEvent<string, string, string, bool> { }

    [System.Serializable]
    public class SSSO : UnityEvent<string, string, string, object> { }

    [System.Serializable]
    public class SSBF : UnityEvent<string, string, bool, float> { }

    [System.Serializable]
    public class SSBI : UnityEvent<string, string, bool, int> { }

    [System.Serializable]
    public class SSBS : UnityEvent<string, string, bool, string> { }

    [System.Serializable]
    public class SSBB : UnityEvent<string, string, bool, bool> { }

    [System.Serializable]
    public class SSBO : UnityEvent<string, string, bool, object> { }

    [System.Serializable]
    public class SSOF : UnityEvent<string, string, object, float> { }

    [System.Serializable]
    public class SSOI : UnityEvent<string, string, object, int> { }

    [System.Serializable]
    public class SSOS : UnityEvent<string, string, object, string> { }

    [System.Serializable]
    public class SSOB : UnityEvent<string, string, object, bool> { }

    [System.Serializable]
    public class SSOO : UnityEvent<string, string, object, object> { }

    [System.Serializable]
    public class SBFF : UnityEvent<string, bool, float, float> { }

    [System.Serializable]
    public class SBFI : UnityEvent<string, bool, float, int> { }

    [System.Serializable]
    public class SBFS : UnityEvent<string, bool, float, string> { }

    [System.Serializable]
    public class SBFB : UnityEvent<string, bool, float, bool> { }

    [System.Serializable]
    public class SBFO : UnityEvent<string, bool, float, object> { }

    [System.Serializable]
    public class SBIF : UnityEvent<string, bool, int, float> { }

    [System.Serializable]
    public class SBII : UnityEvent<string, bool, int, int> { }

    [System.Serializable]
    public class SBIS : UnityEvent<string, bool, int, string> { }

    [System.Serializable]
    public class SBIB : UnityEvent<string, bool, int, bool> { }

    [System.Serializable]
    public class SBIO : UnityEvent<string, bool, int, object> { }

    [System.Serializable]
    public class SBSF : UnityEvent<string, bool, string, float> { }

    [System.Serializable]
    public class SBSI : UnityEvent<string, bool, string, int> { }

    [System.Serializable]
    public class SBSS : UnityEvent<string, bool, string, string> { }

    [System.Serializable]
    public class SBSB : UnityEvent<string, bool, string, bool> { }

    [System.Serializable]
    public class SBSO : UnityEvent<string, bool, string, object> { }

    [System.Serializable]
    public class SBBF : UnityEvent<string, bool, bool, float> { }

    [System.Serializable]
    public class SBBI : UnityEvent<string, bool, bool, int> { }

    [System.Serializable]
    public class SBBS : UnityEvent<string, bool, bool, string> { }

    [System.Serializable]
    public class SBBB : UnityEvent<string, bool, bool, bool> { }

    [System.Serializable]
    public class SBBO : UnityEvent<string, bool, bool, object> { }

    [System.Serializable]
    public class SBOF : UnityEvent<string, bool, object, float> { }

    [System.Serializable]
    public class SBOI : UnityEvent<string, bool, object, int> { }

    [System.Serializable]
    public class SBOS : UnityEvent<string, bool, object, string> { }

    [System.Serializable]
    public class SBOB : UnityEvent<string, bool, object, bool> { }

    [System.Serializable]
    public class SBOO : UnityEvent<string, bool, object, object> { }

    [System.Serializable]
    public class SOFF : UnityEvent<string, object, float, float> { }

    [System.Serializable]
    public class SOFI : UnityEvent<string, object, float, int> { }

    [System.Serializable]
    public class SOFS : UnityEvent<string, object, float, string> { }

    [System.Serializable]
    public class SOFB : UnityEvent<string, object, float, bool> { }

    [System.Serializable]
    public class SOFO : UnityEvent<string, object, float, object> { }

    [System.Serializable]
    public class SOIF : UnityEvent<string, object, int, float> { }

    [System.Serializable]
    public class SOII : UnityEvent<string, object, int, int> { }

    [System.Serializable]
    public class SOIS : UnityEvent<string, object, int, string> { }

    [System.Serializable]
    public class SOIB : UnityEvent<string, object, int, bool> { }

    [System.Serializable]
    public class SOIO : UnityEvent<string, object, int, object> { }

    [System.Serializable]
    public class SOSF : UnityEvent<string, object, string, float> { }

    [System.Serializable]
    public class SOSI : UnityEvent<string, object, string, int> { }

    [System.Serializable]
    public class SOSS : UnityEvent<string, object, string, string> { }

    [System.Serializable]
    public class SOSB : UnityEvent<string, object, string, bool> { }

    [System.Serializable]
    public class SOSO : UnityEvent<string, object, string, object> { }

    [System.Serializable]
    public class SOBF : UnityEvent<string, object, bool, float> { }

    [System.Serializable]
    public class SOBI : UnityEvent<string, object, bool, int> { }

    [System.Serializable]
    public class SOBS : UnityEvent<string, object, bool, string> { }

    [System.Serializable]
    public class SOBB : UnityEvent<string, object, bool, bool> { }

    [System.Serializable]
    public class SOBO : UnityEvent<string, object, bool, object> { }

    [System.Serializable]
    public class SOOF : UnityEvent<string, object, object, float> { }

    [System.Serializable]
    public class SOOI : UnityEvent<string, object, object, int> { }

    [System.Serializable]
    public class SOOS : UnityEvent<string, object, object, string> { }

    [System.Serializable]
    public class SOOB : UnityEvent<string, object, object, bool> { }

    [System.Serializable]
    public class SOOO : UnityEvent<string, object, object, object> { }

    [System.Serializable]
    public class BFFF : UnityEvent<bool, float, float, float> { }

    [System.Serializable]
    public class BFFI : UnityEvent<bool, float, float, int> { }

    [System.Serializable]
    public class BFFS : UnityEvent<bool, float, float, string> { }

    [System.Serializable]
    public class BFFB : UnityEvent<bool, float, float, bool> { }

    [System.Serializable]
    public class BFFO : UnityEvent<bool, float, float, object> { }

    [System.Serializable]
    public class BFIF : UnityEvent<bool, float, int, float> { }

    [System.Serializable]
    public class BFII : UnityEvent<bool, float, int, int> { }

    [System.Serializable]
    public class BFIS : UnityEvent<bool, float, int, string> { }

    [System.Serializable]
    public class BFIB : UnityEvent<bool, float, int, bool> { }

    [System.Serializable]
    public class BFIO : UnityEvent<bool, float, int, object> { }

    [System.Serializable]
    public class BFSF : UnityEvent<bool, float, string, float> { }

    [System.Serializable]
    public class BFSI : UnityEvent<bool, float, string, int> { }

    [System.Serializable]
    public class BFSS : UnityEvent<bool, float, string, string> { }

    [System.Serializable]
    public class BFSB : UnityEvent<bool, float, string, bool> { }

    [System.Serializable]
    public class BFSO : UnityEvent<bool, float, string, object> { }

    [System.Serializable]
    public class BFBF : UnityEvent<bool, float, bool, float> { }

    [System.Serializable]
    public class BFBI : UnityEvent<bool, float, bool, int> { }

    [System.Serializable]
    public class BFBS : UnityEvent<bool, float, bool, string> { }

    [System.Serializable]
    public class BFBB : UnityEvent<bool, float, bool, bool> { }

    [System.Serializable]
    public class BFBO : UnityEvent<bool, float, bool, object> { }

    [System.Serializable]
    public class BFOF : UnityEvent<bool, float, object, float> { }

    [System.Serializable]
    public class BFOI : UnityEvent<bool, float, object, int> { }

    [System.Serializable]
    public class BFOS : UnityEvent<bool, float, object, string> { }

    [System.Serializable]
    public class BFOB : UnityEvent<bool, float, object, bool> { }

    [System.Serializable]
    public class BFOO : UnityEvent<bool, float, object, object> { }

    [System.Serializable]
    public class BIFF : UnityEvent<bool, int, float, float> { }

    [System.Serializable]
    public class BIFI : UnityEvent<bool, int, float, int> { }

    [System.Serializable]
    public class BIFS : UnityEvent<bool, int, float, string> { }

    [System.Serializable]
    public class BIFB : UnityEvent<bool, int, float, bool> { }

    [System.Serializable]
    public class BIFO : UnityEvent<bool, int, float, object> { }

    [System.Serializable]
    public class BIIF : UnityEvent<bool, int, int, float> { }

    [System.Serializable]
    public class BIII : UnityEvent<bool, int, int, int> { }

    [System.Serializable]
    public class BIIS : UnityEvent<bool, int, int, string> { }

    [System.Serializable]
    public class BIIB : UnityEvent<bool, int, int, bool> { }

    [System.Serializable]
    public class BIIO : UnityEvent<bool, int, int, object> { }

    [System.Serializable]
    public class BISF : UnityEvent<bool, int, string, float> { }

    [System.Serializable]
    public class BISI : UnityEvent<bool, int, string, int> { }

    [System.Serializable]
    public class BISS : UnityEvent<bool, int, string, string> { }

    [System.Serializable]
    public class BISB : UnityEvent<bool, int, string, bool> { }

    [System.Serializable]
    public class BISO : UnityEvent<bool, int, string, object> { }

    [System.Serializable]
    public class BIBF : UnityEvent<bool, int, bool, float> { }

    [System.Serializable]
    public class BIBI : UnityEvent<bool, int, bool, int> { }

    [System.Serializable]
    public class BIBS : UnityEvent<bool, int, bool, string> { }

    [System.Serializable]
    public class BIBB : UnityEvent<bool, int, bool, bool> { }

    [System.Serializable]
    public class BIBO : UnityEvent<bool, int, bool, object> { }

    [System.Serializable]
    public class BIOF : UnityEvent<bool, int, object, float> { }

    [System.Serializable]
    public class BIOI : UnityEvent<bool, int, object, int> { }

    [System.Serializable]
    public class BIOS : UnityEvent<bool, int, object, string> { }

    [System.Serializable]
    public class BIOB : UnityEvent<bool, int, object, bool> { }

    [System.Serializable]
    public class BIOO : UnityEvent<bool, int, object, object> { }

    [System.Serializable]
    public class BSFF : UnityEvent<bool, string, float, float> { }

    [System.Serializable]
    public class BSFI : UnityEvent<bool, string, float, int> { }

    [System.Serializable]
    public class BSFS : UnityEvent<bool, string, float, string> { }

    [System.Serializable]
    public class BSFB : UnityEvent<bool, string, float, bool> { }

    [System.Serializable]
    public class BSFO : UnityEvent<bool, string, float, object> { }

    [System.Serializable]
    public class BSIF : UnityEvent<bool, string, int, float> { }

    [System.Serializable]
    public class BSII : UnityEvent<bool, string, int, int> { }

    [System.Serializable]
    public class BSIS : UnityEvent<bool, string, int, string> { }

    [System.Serializable]
    public class BSIB : UnityEvent<bool, string, int, bool> { }

    [System.Serializable]
    public class BSIO : UnityEvent<bool, string, int, object> { }

    [System.Serializable]
    public class BSSF : UnityEvent<bool, string, string, float> { }

    [System.Serializable]
    public class BSSI : UnityEvent<bool, string, string, int> { }

    [System.Serializable]
    public class BSSS : UnityEvent<bool, string, string, string> { }

    [System.Serializable]
    public class BSSB : UnityEvent<bool, string, string, bool> { }

    [System.Serializable]
    public class BSSO : UnityEvent<bool, string, string, object> { }

    [System.Serializable]
    public class BSBF : UnityEvent<bool, string, bool, float> { }

    [System.Serializable]
    public class BSBI : UnityEvent<bool, string, bool, int> { }

    [System.Serializable]
    public class BSBS : UnityEvent<bool, string, bool, string> { }

    [System.Serializable]
    public class BSBB : UnityEvent<bool, string, bool, bool> { }

    [System.Serializable]
    public class BSBO : UnityEvent<bool, string, bool, object> { }

    [System.Serializable]
    public class BSOF : UnityEvent<bool, string, object, float> { }

    [System.Serializable]
    public class BSOI : UnityEvent<bool, string, object, int> { }

    [System.Serializable]
    public class BSOS : UnityEvent<bool, string, object, string> { }

    [System.Serializable]
    public class BSOB : UnityEvent<bool, string, object, bool> { }

    [System.Serializable]
    public class BSOO : UnityEvent<bool, string, object, object> { }

    [System.Serializable]
    public class BBFF : UnityEvent<bool, bool, float, float> { }

    [System.Serializable]
    public class BBFI : UnityEvent<bool, bool, float, int> { }

    [System.Serializable]
    public class BBFS : UnityEvent<bool, bool, float, string> { }

    [System.Serializable]
    public class BBFB : UnityEvent<bool, bool, float, bool> { }

    [System.Serializable]
    public class BBFO : UnityEvent<bool, bool, float, object> { }

    [System.Serializable]
    public class BBIF : UnityEvent<bool, bool, int, float> { }

    [System.Serializable]
    public class BBII : UnityEvent<bool, bool, int, int> { }

    [System.Serializable]
    public class BBIS : UnityEvent<bool, bool, int, string> { }

    [System.Serializable]
    public class BBIB : UnityEvent<bool, bool, int, bool> { }

    [System.Serializable]
    public class BBIO : UnityEvent<bool, bool, int, object> { }

    [System.Serializable]
    public class BBSF : UnityEvent<bool, bool, string, float> { }

    [System.Serializable]
    public class BBSI : UnityEvent<bool, bool, string, int> { }

    [System.Serializable]
    public class BBSS : UnityEvent<bool, bool, string, string> { }

    [System.Serializable]
    public class BBSB : UnityEvent<bool, bool, string, bool> { }

    [System.Serializable]
    public class BBSO : UnityEvent<bool, bool, string, object> { }

    [System.Serializable]
    public class BBBF : UnityEvent<bool, bool, bool, float> { }

    [System.Serializable]
    public class BBBI : UnityEvent<bool, bool, bool, int> { }

    [System.Serializable]
    public class BBBS : UnityEvent<bool, bool, bool, string> { }

    [System.Serializable]
    public class BBBB : UnityEvent<bool, bool, bool, bool> { }

    [System.Serializable]
    public class BBBO : UnityEvent<bool, bool, bool, object> { }

    [System.Serializable]
    public class BBOF : UnityEvent<bool, bool, object, float> { }

    [System.Serializable]
    public class BBOI : UnityEvent<bool, bool, object, int> { }

    [System.Serializable]
    public class BBOS : UnityEvent<bool, bool, object, string> { }

    [System.Serializable]
    public class BBOB : UnityEvent<bool, bool, object, bool> { }

    [System.Serializable]
    public class BBOO : UnityEvent<bool, bool, object, object> { }

    [System.Serializable]
    public class BOFF : UnityEvent<bool, object, float, float> { }

    [System.Serializable]
    public class BOFI : UnityEvent<bool, object, float, int> { }

    [System.Serializable]
    public class BOFS : UnityEvent<bool, object, float, string> { }

    [System.Serializable]
    public class BOFB : UnityEvent<bool, object, float, bool> { }

    [System.Serializable]
    public class BOFO : UnityEvent<bool, object, float, object> { }

    [System.Serializable]
    public class BOIF : UnityEvent<bool, object, int, float> { }

    [System.Serializable]
    public class BOII : UnityEvent<bool, object, int, int> { }

    [System.Serializable]
    public class BOIS : UnityEvent<bool, object, int, string> { }

    [System.Serializable]
    public class BOIB : UnityEvent<bool, object, int, bool> { }

    [System.Serializable]
    public class BOIO : UnityEvent<bool, object, int, object> { }

    [System.Serializable]
    public class BOSF : UnityEvent<bool, object, string, float> { }

    [System.Serializable]
    public class BOSI : UnityEvent<bool, object, string, int> { }

    [System.Serializable]
    public class BOSS : UnityEvent<bool, object, string, string> { }

    [System.Serializable]
    public class BOSB : UnityEvent<bool, object, string, bool> { }

    [System.Serializable]
    public class BOSO : UnityEvent<bool, object, string, object> { }

    [System.Serializable]
    public class BOBF : UnityEvent<bool, object, bool, float> { }

    [System.Serializable]
    public class BOBI : UnityEvent<bool, object, bool, int> { }

    [System.Serializable]
    public class BOBS : UnityEvent<bool, object, bool, string> { }

    [System.Serializable]
    public class BOBB : UnityEvent<bool, object, bool, bool> { }

    [System.Serializable]
    public class BOBO : UnityEvent<bool, object, bool, object> { }

    [System.Serializable]
    public class BOOF : UnityEvent<bool, object, object, float> { }

    [System.Serializable]
    public class BOOI : UnityEvent<bool, object, object, int> { }

    [System.Serializable]
    public class BOOS : UnityEvent<bool, object, object, string> { }

    [System.Serializable]
    public class BOOB : UnityEvent<bool, object, object, bool> { }

    [System.Serializable]
    public class BOOO : UnityEvent<bool, object, object, object> { }

    [System.Serializable]
    public class OFFF : UnityEvent<object, float, float, float> { }

    [System.Serializable]
    public class OFFI : UnityEvent<object, float, float, int> { }

    [System.Serializable]
    public class OFFS : UnityEvent<object, float, float, string> { }

    [System.Serializable]
    public class OFFB : UnityEvent<object, float, float, bool> { }

    [System.Serializable]
    public class OFFO : UnityEvent<object, float, float, object> { }

    [System.Serializable]
    public class OFIF : UnityEvent<object, float, int, float> { }

    [System.Serializable]
    public class OFII : UnityEvent<object, float, int, int> { }

    [System.Serializable]
    public class OFIS : UnityEvent<object, float, int, string> { }

    [System.Serializable]
    public class OFIB : UnityEvent<object, float, int, bool> { }

    [System.Serializable]
    public class OFIO : UnityEvent<object, float, int, object> { }

    [System.Serializable]
    public class OFSF : UnityEvent<object, float, string, float> { }

    [System.Serializable]
    public class OFSI : UnityEvent<object, float, string, int> { }

    [System.Serializable]
    public class OFSS : UnityEvent<object, float, string, string> { }

    [System.Serializable]
    public class OFSB : UnityEvent<object, float, string, bool> { }

    [System.Serializable]
    public class OFSO : UnityEvent<object, float, string, object> { }

    [System.Serializable]
    public class OFBF : UnityEvent<object, float, bool, float> { }

    [System.Serializable]
    public class OFBI : UnityEvent<object, float, bool, int> { }

    [System.Serializable]
    public class OFBS : UnityEvent<object, float, bool, string> { }

    [System.Serializable]
    public class OFBB : UnityEvent<object, float, bool, bool> { }

    [System.Serializable]
    public class OFBO : UnityEvent<object, float, bool, object> { }

    [System.Serializable]
    public class OFOF : UnityEvent<object, float, object, float> { }

    [System.Serializable]
    public class OFOI : UnityEvent<object, float, object, int> { }

    [System.Serializable]
    public class OFOS : UnityEvent<object, float, object, string> { }

    [System.Serializable]
    public class OFOB : UnityEvent<object, float, object, bool> { }

    [System.Serializable]
    public class OFOO : UnityEvent<object, float, object, object> { }

    [System.Serializable]
    public class OIFF : UnityEvent<object, int, float, float> { }

    [System.Serializable]
    public class OIFI : UnityEvent<object, int, float, int> { }

    [System.Serializable]
    public class OIFS : UnityEvent<object, int, float, string> { }

    [System.Serializable]
    public class OIFB : UnityEvent<object, int, float, bool> { }

    [System.Serializable]
    public class OIFO : UnityEvent<object, int, float, object> { }

    [System.Serializable]
    public class OIIF : UnityEvent<object, int, int, float> { }

    [System.Serializable]
    public class OIII : UnityEvent<object, int, int, int> { }

    [System.Serializable]
    public class OIIS : UnityEvent<object, int, int, string> { }

    [System.Serializable]
    public class OIIB : UnityEvent<object, int, int, bool> { }

    [System.Serializable]
    public class OIIO : UnityEvent<object, int, int, object> { }

    [System.Serializable]
    public class OISF : UnityEvent<object, int, string, float> { }

    [System.Serializable]
    public class OISI : UnityEvent<object, int, string, int> { }

    [System.Serializable]
    public class OISS : UnityEvent<object, int, string, string> { }

    [System.Serializable]
    public class OISB : UnityEvent<object, int, string, bool> { }

    [System.Serializable]
    public class OISO : UnityEvent<object, int, string, object> { }

    [System.Serializable]
    public class OIBF : UnityEvent<object, int, bool, float> { }

    [System.Serializable]
    public class OIBI : UnityEvent<object, int, bool, int> { }

    [System.Serializable]
    public class OIBS : UnityEvent<object, int, bool, string> { }

    [System.Serializable]
    public class OIBB : UnityEvent<object, int, bool, bool> { }

    [System.Serializable]
    public class OIBO : UnityEvent<object, int, bool, object> { }

    [System.Serializable]
    public class OIOF : UnityEvent<object, int, object, float> { }

    [System.Serializable]
    public class OIOI : UnityEvent<object, int, object, int> { }

    [System.Serializable]
    public class OIOS : UnityEvent<object, int, object, string> { }

    [System.Serializable]
    public class OIOB : UnityEvent<object, int, object, bool> { }

    [System.Serializable]
    public class OIOO : UnityEvent<object, int, object, object> { }

    [System.Serializable]
    public class OSFF : UnityEvent<object, string, float, float> { }

    [System.Serializable]
    public class OSFI : UnityEvent<object, string, float, int> { }

    [System.Serializable]
    public class OSFS : UnityEvent<object, string, float, string> { }

    [System.Serializable]
    public class OSFB : UnityEvent<object, string, float, bool> { }

    [System.Serializable]
    public class OSFO : UnityEvent<object, string, float, object> { }

    [System.Serializable]
    public class OSIF : UnityEvent<object, string, int, float> { }

    [System.Serializable]
    public class OSII : UnityEvent<object, string, int, int> { }

    [System.Serializable]
    public class OSIS : UnityEvent<object, string, int, string> { }

    [System.Serializable]
    public class OSIB : UnityEvent<object, string, int, bool> { }

    [System.Serializable]
    public class OSIO : UnityEvent<object, string, int, object> { }

    [System.Serializable]
    public class OSSF : UnityEvent<object, string, string, float> { }

    [System.Serializable]
    public class OSSI : UnityEvent<object, string, string, int> { }

    [System.Serializable]
    public class OSSS : UnityEvent<object, string, string, string> { }

    [System.Serializable]
    public class OSSB : UnityEvent<object, string, string, bool> { }

    [System.Serializable]
    public class OSSO : UnityEvent<object, string, string, object> { }

    [System.Serializable]
    public class OSBF : UnityEvent<object, string, bool, float> { }

    [System.Serializable]
    public class OSBI : UnityEvent<object, string, bool, int> { }

    [System.Serializable]
    public class OSBS : UnityEvent<object, string, bool, string> { }

    [System.Serializable]
    public class OSBB : UnityEvent<object, string, bool, bool> { }

    [System.Serializable]
    public class OSBO : UnityEvent<object, string, bool, object> { }

    [System.Serializable]
    public class OSOF : UnityEvent<object, string, object, float> { }

    [System.Serializable]
    public class OSOI : UnityEvent<object, string, object, int> { }

    [System.Serializable]
    public class OSOS : UnityEvent<object, string, object, string> { }

    [System.Serializable]
    public class OSOB : UnityEvent<object, string, object, bool> { }

    [System.Serializable]
    public class OSOO : UnityEvent<object, string, object, object> { }

    [System.Serializable]
    public class OBFF : UnityEvent<object, bool, float, float> { }

    [System.Serializable]
    public class OBFI : UnityEvent<object, bool, float, int> { }

    [System.Serializable]
    public class OBFS : UnityEvent<object, bool, float, string> { }

    [System.Serializable]
    public class OBFB : UnityEvent<object, bool, float, bool> { }

    [System.Serializable]
    public class OBFO : UnityEvent<object, bool, float, object> { }

    [System.Serializable]
    public class OBIF : UnityEvent<object, bool, int, float> { }

    [System.Serializable]
    public class OBII : UnityEvent<object, bool, int, int> { }

    [System.Serializable]
    public class OBIS : UnityEvent<object, bool, int, string> { }

    [System.Serializable]
    public class OBIB : UnityEvent<object, bool, int, bool> { }

    [System.Serializable]
    public class OBIO : UnityEvent<object, bool, int, object> { }

    [System.Serializable]
    public class OBSF : UnityEvent<object, bool, string, float> { }

    [System.Serializable]
    public class OBSI : UnityEvent<object, bool, string, int> { }

    [System.Serializable]
    public class OBSS : UnityEvent<object, bool, string, string> { }

    [System.Serializable]
    public class OBSB : UnityEvent<object, bool, string, bool> { }

    [System.Serializable]
    public class OBSO : UnityEvent<object, bool, string, object> { }

    [System.Serializable]
    public class OBBF : UnityEvent<object, bool, bool, float> { }

    [System.Serializable]
    public class OBBI : UnityEvent<object, bool, bool, int> { }

    [System.Serializable]
    public class OBBS : UnityEvent<object, bool, bool, string> { }

    [System.Serializable]
    public class OBBB : UnityEvent<object, bool, bool, bool> { }

    [System.Serializable]
    public class OBBO : UnityEvent<object, bool, bool, object> { }

    [System.Serializable]
    public class OBOF : UnityEvent<object, bool, object, float> { }

    [System.Serializable]
    public class OBOI : UnityEvent<object, bool, object, int> { }

    [System.Serializable]
    public class OBOS : UnityEvent<object, bool, object, string> { }

    [System.Serializable]
    public class OBOB : UnityEvent<object, bool, object, bool> { }

    [System.Serializable]
    public class OBOO : UnityEvent<object, bool, object, object> { }

    [System.Serializable]
    public class OOFF : UnityEvent<object, object, float, float> { }

    [System.Serializable]
    public class OOFI : UnityEvent<object, object, float, int> { }

    [System.Serializable]
    public class OOFS : UnityEvent<object, object, float, string> { }

    [System.Serializable]
    public class OOFB : UnityEvent<object, object, float, bool> { }

    [System.Serializable]
    public class OOFO : UnityEvent<object, object, float, object> { }

    [System.Serializable]
    public class OOIF : UnityEvent<object, object, int, float> { }

    [System.Serializable]
    public class OOII : UnityEvent<object, object, int, int> { }

    [System.Serializable]
    public class OOIS : UnityEvent<object, object, int, string> { }

    [System.Serializable]
    public class OOIB : UnityEvent<object, object, int, bool> { }

    [System.Serializable]
    public class OOIO : UnityEvent<object, object, int, object> { }

    [System.Serializable]
    public class OOSF : UnityEvent<object, object, string, float> { }

    [System.Serializable]
    public class OOSI : UnityEvent<object, object, string, int> { }

    [System.Serializable]
    public class OOSS : UnityEvent<object, object, string, string> { }

    [System.Serializable]
    public class OOSB : UnityEvent<object, object, string, bool> { }

    [System.Serializable]
    public class OOSO : UnityEvent<object, object, string, object> { }

    [System.Serializable]
    public class OOBF : UnityEvent<object, object, bool, float> { }

    [System.Serializable]
    public class OOBI : UnityEvent<object, object, bool, int> { }

    [System.Serializable]
    public class OOBS : UnityEvent<object, object, bool, string> { }

    [System.Serializable]
    public class OOBB : UnityEvent<object, object, bool, bool> { }

    [System.Serializable]
    public class OOBO : UnityEvent<object, object, bool, object> { }

    [System.Serializable]
    public class OOOF : UnityEvent<object, object, object, float> { }

    [System.Serializable]
    public class OOOI : UnityEvent<object, object, object, int> { }

    [System.Serializable]
    public class OOOS : UnityEvent<object, object, object, string> { }

    [System.Serializable]
    public class OOOB : UnityEvent<object, object, object, bool> { }

    [System.Serializable]
    public class OOOO : UnityEvent<object, object, object, object> { }

}