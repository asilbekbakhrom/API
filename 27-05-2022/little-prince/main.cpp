#include <iostream>
#include <cmath>

using namespace std;

bool isInPlanet(int x, int y, int cX, int cY, int cR)
{
	int distanceToRadius = pow(x - cX, 2) + pow(y - cY, 2);

	if(distanceToRadius < pow(cR, 2))
	{
		return true;
	}

	return false;
}

bool hasCrossing(int startX, int startY, int endX, int endY, int pX, int pY, int pR)
{
	if(isInPlanet(startX, startY, pX, pY, pR) && 
		!isInPlanet(endX, endY, pX, pY, pR))
	{
		return true;
	}
	else if(!isInPlanet(startX, startY, pX, pY, pR) && 
		isInPlanet(endX, endY, pX, pY, pR))
	{
		return true;
	}

	return false;
}

int crossings()
{
	int startX, startY, endX, endY;
	cin >> startX >> startY >> endX >> endY;

	int planets;
	cin >> planets;

	int count = 0;
	while(planets--)
	{
		int pX, pY, pR;
		cin >> pX >> pY >> pR;

		if(hasCrossing(startX, startY, endX, endY, pX, pY, pR))
		{
			count++;
		}
	}

	return count;
}

int main() 
{
	int testCases;

	cin >> testCases;

	while(testCases--)
	{
		int kesibOtishlar = 0;

		kesibOtishlar = crossings();

		cout << kesibOtishlar << endl;
	}
	
	return 0;
}