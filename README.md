# 🎰 Unity Slot Machine Prototype  

A **3-Reel Slot Machine Game** built in **Unity (2025.6000.x)** as part of an internship assignment.  
This project demonstrates skills in **C#, UI/UX design, persistence, audio integration, and modular architecture** for game development.  

---

## ✨ Features  

- **Core Gameplay**:  
  - 3 reels, 7 classic symbols (🍋 🍒 7 💎 ❤️ 🍉 🧲)  
  - Weighted randomness for fair odds  
  - Flexible paytable system  

- **Bankroll System**:  
  - Adjustable bets with +/− buttons  
  - Balance updates dynamically  
  - Reset option  

- **Auto-Spin**:  
  - Continuous spins with toggle  
  - Saves auto-spin state between sessions  

- **Persistence**:  
  - Balance, bet, and auto-spin saved with `PlayerPrefs`  

- **UI/UX**:  
  - Custom button graphics from **Figma**  
  - Responsive Canvas for desktop/WebGL  
  - Animated win banner  

- **Audio**:  
  - Background music (looping)  
  - Reel spin sounds  
  - Button click sounds  
  - Win/jackpot fanfare  

---

## 🛠️ Tech Stack  

- **Engine**: Unity (2025 LTS)  
- **Language**: C#  
- **Architecture**:  
  - Clean separation of concerns  
  - Managers → `UIController`, `SlotMachineController`, `BankrollManager`, `AudioManager`  
  - Data-driven ScriptableObjects → `SymbolData`, `ReelConfig`, `Paytable`  

---

## 🎨 Assets  

- 🎨 UI & button designs: Created in **Figma**  
- 🎰 Symbols & sprites: Free packs from [Kenney.nl](https://kenney.nl) and Unity Asset Store  
- 🔊 Sounds: Free casino-style SFX and background music  

---

## ▶️ How to Play  

1. Adjust bet with **+ / −**  
2. Press **Spin** to roll the reels  
3. Match 3 symbols on the center row to win  
4. Use **Reset** to restore bankroll  
5. Toggle **Auto-Spin** for continuous play  

---

## 🚀 Future Improvements  

- Multiple paylines & bonus rounds  
- Particle effects for jackpots  
- Advanced reel animations (scrolling reels)  
- More sound variety and visual polish  

---

## 📂 Repository Structure  
Scripts/
- ├── Managers/
- │ ├── SlotMachineController.cs
- │ ├── BankrollManager.cs
- │ ├── UIController.cs
- │ ├── AudioManager.cs
- │
- ├── Systems/
- │ ├── SaveSystem.cs
- │
- ├── Data/
- │ ├── SymbolData.cs
- │ ├── ReelConfig.cs
- │ ├── Paytable.cs
- Art/
- Audio/
- Scenes/
  
---

## 📜 License  

This project is for educational and portfolio purposes.  
Assets are credited to their respective creators (Kenney, Unity Asset Store, Figma exports).  


