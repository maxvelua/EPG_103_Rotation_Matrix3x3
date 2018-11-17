# One object mirror the behaviour of another object
Using Matrix 3x3 and Euler angels
## Realize structure Matrix3x3 with functions: 
```
Rotate - using angle in degres and axis(x,y,z) return Matrix3x3
Euler - converts Euler angles to a rotation matrix return Matrix3x3
Operator * (Matrix*Matrix) - for multiplication Matrix3x3 return Matrix3x3
Operator * (Matrix*Vector3) - for multiplication Matrix3x3 and Vector3 return Vector3
```
### PlayerBehaviour script
Need for mirror the behaviour <br />
Script gets an object for mirror, then in Update function gets his rotation in Euler angles to Vector3 and convert Vector3 using matrix Euler function, then create a final matrix which consist with multiplication rotation matrices using Euler angles y,x,z and axis y,x,z and writes the multiplication of this matrix and Vector3.forward to transform.forward and multiplication with Vector3.up to transform.up


