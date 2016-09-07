using System;
using System.Collections.Generic;

namespace PostSecondaryPassport
{
	public interface Route

	{
		String getRouteName();
		LevelPage getStartLevel();
	}
}

