
# Tile-level precise culling (x_hat)

This adds a compute kernel `CS_TileCull` to cull splats per tile using the maximum-contribution point x_hat:
1) Project splat mean to screen (pixels).
2) Estimate screen-space sigma from world scale and depth.
3) Clamp the mean to the tile rectangle to obtain x_hat.
4) Evaluate Gaussian value at x_hat: exp(-0.5 * d^2).
5) Keep if >= epsilon, otherwise cull.

Parameters:
- TileSize: tile width/height in pixels.
- CullEpsilon: contribution threshold; start at 1e-4 and tune per scene.
- ScreenSize/View/Proj: from camera.

Integration:
- Use the provided diff to bind and dispatch after your `CalcViewData` (so camera matrices are ready) and before sorting/drawing.
- Initially use Option A (KeepFlags-aware draw). If perf is a concern, implement Option B (compaction).
