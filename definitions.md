# Definitions

### What is a base:
A base is a collection of attributes that determine the rules of how a value is represented.

Attributes:
1. The base's value
2. Polarity
3. Format
4. Echo
5. Velocity
6. Direction

### What is a Basal number:
A Basal number is a value, but that value is represented via the base, which is found on the plane (default), or is following / trailing it.

E.g. `<11T 1 , 0 , 2 , 9 , 3`

`<11T` is the base, and `1 , 0 , 2 , 9 , 3` is the collection of characters / digits. Together, the value is Fourteen thousand, nine hundred and eighty five.

### What determines equality:
Equality between basal numbers comes from the value, not the base or how it is represented.

Therefore:
```
<12T 6541 = 1456 T12>  These numbers have the same value, just different direction of base
<10গT 14, 29 = <10T 1, 6, 9 = <10T 169
```

### Rules of operations
The operating symbol's rules are the same as regular maths, and operations are carried out by converting both numbers to the same base (if they aren't already), performing the operation, then converting the result to the target base (or you could convert both numbers to the target base before performing the operation)

E.g.
```
<3গT 15, 7, 6, 4, 0 + <3T 2, 1, 2, 0 = <3গT 15, 9, 7, 6, 0 = <3T 2010000 = 1539

<3গT 15, 7, 6, 4, 0 x <3T 2, 1, 2, 0 = <3T 12011010200 = <10T 101430
```

### Gist of what the basal attributes do:
The base's value determines the value exponentiated by the index.

The polarity determines the effect of every other digit, positionally. (See Documentation/Base_Attributes/Polarity.md)

The format sets the base's digit-limit rule as true or false. Regular - True ; Discrete - False

The echo determines the order of the digits, algorithm to move them to and back is positional. (See Documentation/Base_Attributes/Echo.md)

The velocity determines the change in index per digit. (See Documentation/Base_Attributes/Velocity.md)

The direction determines if the MSD (Most Significant Digit) is the left-most, or the right-most.
<10T 123 = 123 = 321 T10>

### What can be a digit:
A digit is any value in the collection, represented by the base of the plane (default is <10T - denary).

A digit is usually the characters 0-9 and some letters.

A digit could also be a dual number, a complex number, a variable, another equation, a fraction, a decimal, or the output of a function (requires array syntax).

E.g.

let f(x) = 3x + 5

<10গT y, y, f(7), 1 = <16T 2, 3, 1

y = 3