using System.Numerics;

Func<int,bool> lastDigitsPandigital = n => {
	bool[] occured = {true, false, false, false, false, false, false, false, false, false};
	for(int i = 0; i < 9; i++){
		var digit = n % 10;
		if(occured[digit]){
			return false;
		}
		occured[digit] = true;
		n /= 10;
	}
	return true;
};

var nineDigits = new BigInteger(1000000000);

Func<BigInteger,bool> firstDigitsPandigital = n => {
	while(n >= nineDigits){
		n /= 10;
	}
	return lastDigitsPandigital((int)n);
};

Func<int,BigInteger,bool> firstAndLastDigitsPandigital = (nlast, n) => {
	if(!lastDigitsPandigital(nlast)){
		return false;
	}
	return firstDigitsPandigital(n);
};

int i = 2, lastA = 1, lastBe = 1;
BigInteger a = new BigInteger(1), b = new BigInteger(1);

while(!firstAndLastDigitsPandigital(lastB, b)){
	var sum = a+b;
	a = b;
	b = sum;
	var lastSum = (lastA + lastB) % 1000000000;
	lastA = lastB;
	lastB = lastSum;
	i++;
}

Console.WriteLine(i);
