// ProblemA.Bullseye.Cpp.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <sstream>
using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	
	ifstream infile("../A-sample.in");
	ofstream outfile("../A-sample.out");
	
	string line;
	getline(infile, line);
	int casesCount = _strtoui64(line.c_str);

    for (int i = 0; i < casesCount; ++i)
    {

	unsigned __int64 r = 1;
	unsigned __int64 t = 1000000000000000000;
	int y = 0;  //always at least 1

	//computation
	while (true)
	{
		//float small = r * r;
		//float big = (r + 1) * (r + 1);
		//t -= (big - small);
		unsigned __int64 area = 2 * r + 1;
		if (t >= area)
		{
			t -= area;
			++y;
			r += 2;
		}
		else
			break;
	}

	//output
	cout << "Case #" << (1) << ": " << y;
	return 0;
}

