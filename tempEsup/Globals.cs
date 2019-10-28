using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tempEsup
{
    public static class Globals
    {

        public static int LKAA_MIN() {
            return 1400;
        }

        public static int LKAA_MAX()
        {
            return 1477;
        }

        public static int LKAA_DOM_MIN()
        {
            return 3352;
        }

        public static int LKAA_DOM_MAX()
        {
            return 3377;
        }

        public static int LKAA_WEST_MIN()
        {
            return 6620;
        }

        public static int LKAA_WEST_MAX()
        {
            return 6637;
        }

        public static int LKTB_CTA_MIN()
        {
            return 0020;
        }

        public static int LKTB_CTA_MAX()
        {
            return 0027;
        }

        public static int LKMT_CTA_MIN()
        {
            return 0030;
        }

        public static int LKMT_CTA_MAX()
        {
            return 0037;
        }

        public static int LKPR_MIN()
        {
            return 3310;
        }

        public static int LKPR_MAX()
        {
            return 3317;
        }

        public static int LKTB_MIN()
        {
            return 3320;
        }

        public static int LKTB_MAX()
        {
            return 3327;
        }

        public static int LKMT_MIN()
        {
            return 3345;
        }

        public static int LKMT_MAX()
        {
            return 3347;
        }

        public static int LKKV_MIN()
        {
            return 3350;
        }

        public static int LKKV_MAX()
        {
            return 3351;
        }

        public static int LKPD_MIN()
        {
            return 7020;
        }

        public static int LKPD_MAX()
        {
            return 7027;
        }

        public static int LKVO_MIN()
        {
            return 3301;
        }

        public static int LKVO_MAX()
        {
            return 3304;
        }

        public static int LKCV_MIN()
        {
            return 7040;
        }

        public static int LKCV_MAX()
        {
            return 7047;
        }

        public static int LKNA_MIN()
        {
            return 7010;
        }

        public static int LKNA_MAX()
        {
            return 7017;
        }

        public static int LKKB_MIN()
        {
            return 7070;
        }

        public static int LKKB_MAX()
        {
            return 7077;
        }

        public static int LKAA_VFR_MIN()
        {
            return 3330;
        }

        public static int LKAA_VFR_MAX()
        {
            return 3344;
        }

        public static int LKAA_MAN_MIN()
        {
            return 5170;
        }

        public static int LKAA_MAN_MAX()
        {
            return 5177;
        }

        public static int initial = 1000;
        public static int previous = 0;
        public static int previousLKAA = 0;
        public static int previousLKAAdom = 0;
        public static int prevLKAAwest = 0;
        public static int prevLKPR = 0;
        public static int prevLKTB = 0;
        public static int prevLKMT = 0;
        public static int prevLKKV = 0;
        public static int prevLKPD = 0;
        public static int prevLKVO = 0;
        public static int prevLKNA = 0;
        public static int prevLKCV = 0;
        public static int prevLKKB = 0;
        public static int prevLKAAvfr = 0;
        public static int prevLKAAmnl = 0;
        public static int prevLKTBcta = 0;
        public static int prevLKMTcta = 0;
    }
}
