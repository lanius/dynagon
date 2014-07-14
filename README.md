Dynagon
=======

Dynamically generates polygon meshes in Unity. It implements 2D/3D Delaunay triangulation.


Demo
----

[![Dynagon demo](http://img.youtube.com/vi/w4kD1Ezzt0c/0.jpg)](https://www.youtube.com/watch?v=w4kD1Ezzt0c)


Usage
-----

Drop Dynagon folder into Assets of the project.

Can create meshes from vertices:

```cs
using UnityEngine;
using System.Collections.Generic;
using Dynagon;

var vertices = new List<Vector3>() {
    new Vector3(0f, 1f, 0f),
    new Vector3(0f, -0.3f, 0.9f),
    new Vector3(0.8f, -0.3f, -0.5f),
    new Vector3(-0.8f, -0.3f, -0.5f)
};

Factory.Create(vertices);
```

Or separately, can triangulate and create a polygon:

```cs
var triangles = Triangulator3D.Triangulate(vertices);
new Polygon3D(new GameObject(), triangles).Build();
```

See samples for more details.

