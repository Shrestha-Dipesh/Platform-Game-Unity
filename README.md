# 🎮 Gesture-Controlled 2D Platform Game (Unity)

A **2D platformer game built with Unity** that supports both **traditional keyboard controls** and **real-time hand-gesture control** using **OpenCV and MediaPipe**.  
This project was developed as a **final-year (capstone) project** for the **BSc (Hons) Computing** program.

---

## 📌 Project Overview

This project explores an **alternative human–computer interaction (HCI)** approach for gaming by enabling **gesture-based character control** without specialized hardware.

The project delivers a **complete end-to-end game product**, including:
- Core gameplay built in **Unity (C#)**
- Gesture recognition implemented in **Python**
- A **custom promotional website** that allows users to download PC and Android builds **without installing Unity**

---

## ✨ Key Features

- 🎮 Fully functional 2D platformer
- ✋ Real-time **hand gesture–controlled movement**
- ⌨️ Keyboard input fallback
- 🌟 Unity Particle System effects
- 🧍 Animated player, enemies, and environment
- 🎨 100% custom-designed sprites & UI assets
- 🔊 Original background music & sound effects
- 🧭 Multiple scenes (Intro, Menu, Tutorial, Levels)
- 🌐 Standalone website for game download (PC & Android)
- 🧪 Black-box, white-box, integration, alpha & beta testing

---

## 🕹️ Gesture Control System

The gesture control system is implemented as a **separate Python module** that communicates with the Unity game by **simulating keyboard inputs**.

### Supported Gestures

| Gesture | Action |
|------|------|
| ✋ Single open hand | Move forward |
| ✊ Single closed hand | Move backward |
| ✋✋ Double open hands | Jump forward |
| ✊✊ Double closed hands | Jump backward |
| `Q` key | Stop camera capture |

### Technologies Used
- **Python**
- **OpenCV**
- **MediaPipe (Hands solution)**

---

## 🛠️ Technology Stack

### Game Engine
- Unity (2D)
- C#

### Gesture Recognition
- Python
- OpenCV
- MediaPipe

### Web & Distribution
- HTML, CSS, JavaScript
- Inno Setup Compiler (Windows installer)

### Tools
- Adobe Photoshop & Illustrator
- Audacity / Bosca Ceoil
- Visual Studio / PyCharm / VS Code
- Git & GitHub
- Trello & Discord

---

## 📂 Project Structure

```text
Platform-Game-Unity/
├── Assets/
├── Gesture-Control/
│   ├── directkeys.py
│   └── main.py
├── Website/
└── README.md
```

---

## 🚀 How to Run the Project

### Option 1: Play via Downloaded Build (Recommended)
1. Open the **Website** folder
2. Launch `index.html`
3. Download the PC setup or Android APK
4. Install and play — **no Unity required**

### Option 2: Run from Source

#### Prerequisites
- Unity Hub + Unity Editor (2D template)
- Python 3.x
- Webcam (for gesture control)

#### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/Shrestha-Dipesh/Platform-Game-Unity.git
   ```
2. Open the project in **Unity Hub**
3. Install Python dependencies:
   ```bash
   pip install opencv-python mediapipe
   ```
4. Run the gesture control Python script
5. Play the game using **hand gestures or keyboard**

---

## 🧪 Testing & Evaluation

- ✔ Functional requirements fully met
- ✔ Multi-hand detection implemented
- ✔ Python–Unity integration tested
- ✔ User feedback collected via beta testing
- ✔ Project goals achieved within revised timeline

---

## 👤 Author

**Dipesh Shrestha**  
BSc (Hons) Computing – Final Year Project  
The British College, Kathmandu

---

## 📄 License

This project is for **educational and research purposes**.
