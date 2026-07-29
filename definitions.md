# Definitions

## Fundamentals:
### What is a base:
A base is a collection of attributes that determine the rules of how a value is represented.

Attributes:
1. The base's value
2. Polarity
3. Format
4. Echo
5. Velocity
6. Direction

### Gist of what the basal attributes do:
The base's value determines the value exponentiated by the index.

The polarity determines the effect of every other digit, positionally. (See [Polarity](Documentation/Base_Attributes/Polarity.md))

The format sets the base's digit-limit rule as true or false. Regular - True ; Discrete - False

The echo determines the order of the digits, algorithm to move them to and back is positional. (See [Echo](Documentation/Base_Attributes/Echo.md))

The velocity determines the change in index per digit. (See [Velocity](Documentation/Base_Attributes/Velocity.md))

The direction determines if the MSP (Most Significant Position) is the left-most, or the right-most.
<10T 123 = 123 = 321 T10>

### What is a Basal number:
A Basal number is a value, but that value is represented via the base, which is found on the plane (default), or is following / trailing it.

E.g. `<11T 1 , 0 , 2 , 9 , 3`

`<11T` is the base, and `1 , 0 , 2 , 9 , 3` is the collection of characters / digits. Together, the value is Fourteen thousand, nine hundred and eighty five.

Referring to any base: {Discreted / blank},
             {Negative / Double Negative / blank, },
             {Base [base_value]},
             {Velocity of [velocity] / blank}

### Array and Word syntaxes:
Array and word syntaxes are ways to write a basal number

E.g.
```
1234569 = 1 , 2 , 3 , 4 , 5 , 6 , 9
```

### What determines equality:
Equality between basal numbers comes from the value, not the base or how it is represented.

Therefore:
```
<12T 6541 = 1456 T12>  These numbers have the same value, just different direction of base
<10গT 14, 29 = <10T 1, 6, 9 = <10T 169
```

### Rules of operations:
The operating symbol's rules are the same as regular maths, and operations are carried out by converting both numbers to the same base (if they aren't already), performing the operation, then converting the result to the target base (or you could convert both numbers to the target base before performing the operation)

E.g.
```
<3গT 15, 7, 6, 4, 0 + <3T 2, 1, 2, 0 = <3গT 15, 9, 7, 6, 0 = <3T 2010000 = 1539

<3গT 15, 7, 6, 4, 0 x <3T 2, 1, 2, 0 = <3T 12011010200 = <10T 101430
```

### What can be a digit:
A digit is any value in the collection, represented by the base of the plane (default is <10T - denary).

A digit is usually the characters 0-9 and letters (both syntaxes).

A digit could also be a dual number, a complex number, a variable, another equation, a fraction, a decimal, or the output of a function (requires array syntax).

E.g.
```
let f(x) = 3x + 5

<10গT y, y, f(7), 1.2 = <16T 2, 3, 1.2

y = 3
```

## Functions:
### [Basal fabrication](Documentation/Other_Functions/fabrication.md):
You can use any function / equation to make a basal number, with a ranged method (similar to a for-loop).

### Basal polynomials:
With the base's value as a variable, you can make the number a polynomial function

E.g. <xT 1, -6, 2, 0, .7 = x^3 - 6x^2 + 2x + 7x^-1

### Basal stacking:
You can stack bases onto a single number, where the number's digit values will be the individual product of each digit's indexes from all bases acting on it. The bases can be of any combination of attributes.

E.g.
```
You can also put all bases on either side of the number

<4দগT <3গT 4, 5, 7, 8, 1, 9, 52, 142 T9গ> = <4দগT <3গT T9গ> 4, 5, 7, 8, 1, 9, 52, 142

Calculation: <10গT 143327232, 134369280, 141087744, 120932352, 11337408, 76527504, 331619184, 679181598         
```

### [Singularitive operations](Documentation/Other_Functions/singularity.md):
Digit-wise operations on numbers.

### [Shifting](Documentation/Other_Functions/shifts.md):
You can move the decimal point of a number, changing its value without. This does not discard digits.

## [Ease of use](Documentation/Notation/Ease_of_use.md):
### Base of plane:
The workspace / plane can have a base that does not need defining, acts as the default.
### Base Pointer:
You can set a base as a variable to be accessed throughout the plane.
### Charactersets:
A characterset can be defined for the plane.

## Conversions:

### [Of Basal Numbers](Documentation/Converting_Bases/converting.md):
Get the value of the number you want to convert, and calculate the digit collection in the following order:
1. Base value and velocity (percieve it as {base value ^ velocity})
2. Polarity
3. Echo
4. Direction

### First Method:
Converting an arbitary base to another, by using the input number's base 
### Second Method:
Converting an arbitary base to another, by using a given base (has to be discrete), converting the input number as if it were that

### For attributes:
1. [Acceleration](Documentation/Converting_Bases/acceleration.md) (change of velocity)
2. [Depolarisation](Documentation/Converting_Bases/depolarising.md) (change of polarity)
3. [Rippllification](Documentation/Converting_Bases/rippllification.md) (change of ripple and echo)