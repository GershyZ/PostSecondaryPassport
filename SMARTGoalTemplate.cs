using System;
namespace PostSecondaryPassport
{
	public class SMARTGoalTemplate
	{
		String sdetail, mdetail, adetail;
		public SMARTGoalTemplate(String sform, String mform, String aform)
		{
			sdetail = sform;
			mdetail = mform;
			adetail = aform;
		}

		public String getSDetailLabel()
		{
			return sdetail;
		}
		public String getMDetailLabel()
		{
			return mdetail;
		}
		public String getADetailLabel()
		{
			return adetail;
		}
	}
}

