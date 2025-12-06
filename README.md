# Third-Person Survival Arena  
**Course:** 3D Game Basics — KMU 2025  
**Engine:** Unity 2022 LTS  
**Author:** ZUCCHERO MATHIS 7702284  

---

## 🎮 Overview
This project is a third-person survival mini-mission built entirely in Unity 2022 using a custom third-person controller and several gameplay systems: AI navigation, grenade combat, collectibles, a minimap UI, an objective system, and win/lose screens.

The player is deployed on a hostile island where they must retrieve a classified access key, open a locked outpost door, avoid land mines, survive enemy attacks, and reach an extraction zone.

---

## 🧭 Game Flow
1. Player lands on a small island with a custom third-person controller.  
2. The island contains painted terrain, foliage, water, and environmental details.  
3. The player must **find and collect a key** located somewhere on the island.  
4. A locked sliding door blocks access to the outpost.  
   - The door **opens only after the key is collected**.  
5. Enemies guard patrols the outpost area.  
   - Uses **NavMeshAgent**  
   - Chases the player when inside detection radius  
   - Throws grenades at the player while chasing  
6. Combat features:  
   - Enemy grenades deal explosion damage  
   - Player can throw grenades  
   - Enemy dies and ragdolls on explosion  
7. Land mines around the outpost explode on contact.  
8. Helpful and dangerous pickups affect player health.  
9. A **health bar UI** updates in real-time.  
10. A **minimap** displays player, enemy, door, and objective icons.  
11. Win by reaching the **extraction zone** behind the outpost.  
12. Lose when player health reaches zero.

---

## 🕹 Controls
| Action | Key |
|--------|------|
| Move | WASD |
| Look | Mouse |
| Throw Grenade | SPACE |
| Restart (Win/Lose Panel) | Click "Replay" |
| Quit game | Escape |

---

## 🧱 Features Implemented

### ✅ Player & Camera System
- Custom third-person controller (no Starter Assets)  
- Camera orbit system  
- Movement relative to camera direction  
- Cursor lock/unlock  
- Footstep audio  

### ✅ Environment
- Unity Terrain with at least 3 textures (cobblestone, gravel, sand)  
- Trees, rocks, grass  
- Water zone  

### ✅ Key & Door System
- Key pickup with UI & minimap icon  
- Door locked until key collected  
- Automatic opening when key acquired  

### ✅ Enemy AI
- NavMeshAgent movement  
- Detection radius  
- Chasing logic  
- Grenade throwing AI  
- Ragdoll death  
- Minimap enemy icon (removed on death)

### ✅ Combat System
- Grenades (player + enemy)  
- Physics explosion  
- Damage radius  
- Explosion VFX + SFX  

### ✅ Land Mines
- Hidden on minimap  
- Particle explosion  
- Sound effect  
- Instant damage  

### ✅ Pickups & UI
- Heal pickup  
- Damage pickup  
- Health bar with real-time updates  

### ✅ Minimap
- Fixed (non-rotating) minimap  
- Player arrow rotates  
- Enemy icons  
- Door icon  
- Key objective icon (removed when key collected)  
- Automatic icon cleanup  
- Proper world → minimap coordinate conversion  

### ✅ Win/Lose Screens
- Win panel (Mission Complete)  
- Lose panel (Mission Failed)  
- Replay button  
- Game freeze (Time.timeScale = 0)  
- Cursor automatically re-enabled  

### 🎁 **Bonus Implemented**
- Minimap (+2 bonus points)  
- Win/Lose screen (+3 bonus points)  
Total bonus: **+5 points**

---

## 🎯 Objective to Win
After unlocking the outpost door, the player must walk into the **Win Zone**, located behind the door.  
Entering this zone triggers the Mission Complete screen.

---


---

## 📦 Project Structure

Assets/
├── Scripts/
│ ├── Player/
│ ├── AI/
│ ├── Interaction/
│ ├── UI/
│ └── Managers/
├── Prefabs/
├── Materials/
├── Audio/
├── VFX/
├── Scenes/
│ └── MainScene.unity


---

## 🚀 Installation & Run
1. Clone or download the repository  
2. Open in **Unity 2022.x (LTS recommended)**  
3. Load scene: `MainScene.unity`  
4. Press **Play**

---

## 📄 License
This project is open-source under the **MIT License**  

---

## 👤 Author
**Mathis Zucchero**  
**7702284**  
KMU 2025


