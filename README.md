# One object mirror the behaviour of another object
Using Matrix 3x3 and Euler angels
## Realize structure Matrix3x3 with functions: 
<ul>
<li>Rotate - using angle in degres and axis(x,y,z) return Matrix3x3</li>
<li>Euler - converts Euler angles to a rotation matrix return Matrix3x3</li>
<li>operator * (Matrix*Matrix) - for multiplication Matrix3x3 return Matrix3x3</li>
<li>operator * (Matrix*Vector3) - for multiplication Matrix3x3 and Vector3 return Vector3</li>
</ul>
### PlayerBehaviour script
Need for mirror the behaviour<br />
Script gets an object for mirror, then in Update function gets his rotation in Euler angles to Vector3 and convert vector to a rotation matrix, then create a rotation matrix with multiplication rotation matrices using Euler angles y,x,z and axis y,x,z and writes the multiplication of the final matrix and Vector3.forward to transform.forward and multiplication of matrix and Vector3.up to transform.up


