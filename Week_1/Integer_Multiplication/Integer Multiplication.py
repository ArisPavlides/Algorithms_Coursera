import math as mt

num1 = 3141592653589793238462643383279502884197169399375105820974944592
num2 = 271828182845904523536028747135266249775724709369995957496696762


def karatsuba_mul(num1, num2):

    if (num1 < 10) or (num2 < 10):

        return num1*num2

    # calculates the size of the numbers
    m = max(len(str(abs(num1))), len(str(abs(num2))))
    m2 = mt.floor(m/2)

    # split the digit sequences in the middle
    high1, low1 = num1[:m2], num1[m2:]
    high2, low2 = num2[:m2], num2[m2:]

    # 3 calls made to numbers approximately half the size
    z0 = karatsuba_mul(low1, low2)
    z1 = karatsuba_mul((low1 + high1), (low2 + high2))
    z2 = karatsuba_mul(high1, high2)

    return (z2 * 10 ^ (m2 * 2)) + ((z1 - z2 - z0) * 10 ^ m2) + z0


print(karatsuba_mul(num1, num2))