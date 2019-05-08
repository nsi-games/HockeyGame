using UnityEngine;
using System.Collections;

/**
 * Some GLSL-like conversions from Vector3 to Vector2.
 * Implemented as class extensions. So it should be possible to do:
 * 
 * Vector3 v3 = <blah>;
 * Vector2 v2 = v3.zx();
 */
public static class Vector3Extensions  {

	public static Vector2 xy(this Vector3 v) {
		return v;
	}

	public static Vector2 xz(this Vector3 v) {
		return new Vector2(v.x, v.z);
	}

	public static Vector2 yz(this Vector3 v) {
		return new Vector2(v.y, v.z);
	}

	public static Vector2 yx(this Vector3 v) {
		return new Vector2(v.y, v.x);
	}

	public static Vector2 zx(this Vector3 v) {
		return new Vector2(v.z, v.x);
	}

	public static Vector2 zy(this Vector3 v) {
		return new Vector2(v.z, v.y);
	}

	public static string longString(this Vector3 v) {
		return string.Format("({0}, {1}, {2})", v.x, v.y, v.z);
	}

	public static Vector3 Rotate(this Vector3 v, float angle, Vector3 axis) {
		return Quaternion.AngleAxis(angle, axis) * v;
	}

}

