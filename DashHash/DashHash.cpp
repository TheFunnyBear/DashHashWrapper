#include "stdafx.h"
#include "dash.h"

extern "C" __declspec(dllexport) void DashHash(const char* input, int len, char* output)
{
	dash_hash(input, len, output);
}
