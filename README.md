# Auto Arrange 3D

**Auto Arrange 3D** is a lightweight Unity tool by **GoodTimesHub** that automatically arranges GameObjects in 3D space, similar to how Unity’s UI Layout Groups work — but for world objects.

---

## ✨ Features

- 🔄 Automatic layout of child GameObjects in X, Y, or Z directions
- 📏 Custom spacing and padding
- 🎯 Align objects easily in a clean, predictable format
- 🧠 Editor-only execution (safe for runtime)
- ⚡ Live updates via `ExecuteAlways` or manual rebuild

---

## 📦 Installation

### Option 1: Unity Package Manager (via Git URL)
Coming soon...

### Option 2: Local Package
1. Clone or download this repository.
2. Open your Unity project.
3. Go to `Window > Package Manager > + > Add package from disk...`
4. Select the `package.json` file.

---

## 🛠 Usage

1. Add the `AutoArrange3D` component to any GameObject.
2. Add child objects underneath it.
3. Choose your layout axis (X, Y, or Z).
4. Adjust spacing and padding as needed.
5. Toggle **Auto Update** or use the **Rebuild Layout** button.

---

## 📂 Folder Structure
AutoArrange3D/
├── Runtime/
│ └── AutoArrange3D.cs
├── Editor/
│ └── AutoArrange3DEditor.cs
├── Resources/
│ └── icon.png (for Unity inspector)
├── package.json
└── README.md

---

## 📸 Example

![Auto Arrange Preview](Documentation~/preview.gif)

---

## 🧠 Author

**Enwongo-Abasi Udomah**  
[GoodTimesHub](https://goodtimeshub.com)  
support@goodtimeshub.com

---

## 🔖 License

MIT License. Free for personal and commercial use. Attribution appreciated but not required.


