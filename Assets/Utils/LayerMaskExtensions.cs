using UnityEngine;
using System.Collections;

public static class LayerMaskExtensions  {

	/**
	 * Check whether a particular gameObject belongs to one of the layers in this mask
	 */

	public static bool Contains(this LayerMask layerMask, GameObject gameObject) {
		return (layerMask.value & (1 << gameObject.layer)) != 0;
	}
}
