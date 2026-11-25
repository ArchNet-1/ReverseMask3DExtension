<p align="center">
  <a href="https://archnet-plateform.fr"><img src="https://archnet-plateform.fr/ArchNetLogoWithBck.png" alt="ArchNet" width="240"></a>
</p>

# ArchNet · Reverse Mask 3D Extension

Darkens the screen with an overlay that has holes over 3D objects; clicks inside a hole reach the object under it.

- Unity **6000.0** or newer · Needs `com.archnet.extension.canvas`, `com.archnet.extension.renderer` (the ArchNet installer adds them for you).
- Part of [ArchNet](https://archnet-plateform.fr), free and open-source Unity packages

## Install

*Window > Package Manager > + > Install package from git URL…*

```
https://github.com/ArchNet-1/ReverseMask3DExtension.git
```

## Use

Put **Reverse Mask 3D Controller** on the overlay and register the holes with `AddMask(mask)`. Clicked 3D objects receive the click and the controller raises **On Object Clicked**.

## License

MIT, see [LICENSE.md](LICENSE.md).
