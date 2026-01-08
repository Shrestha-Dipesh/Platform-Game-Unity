import cv2
import mediapipe
import time
from directkeys import right_key_code, left_key_code, up_key_code
from directkeys import press_key, release_key

# Capture video with default webcam i.e. 0
cam_video = cv2.VideoCapture(0)

draw_media = mediapipe.solutions.drawing_utils
hand_media = mediapipe.solutions.hands
hands = hand_media.Hands()

tips_id = [4, 8, 12, 16, 20]

time.sleep(2.0)
current_key_pressed = set()

while True:
    # Reset key press
    key_pressed = False
    right_key_pressed = False
    left_key_pressed = False
    up_key_pressed = False
    key_count = 0
    key_code = 0

    success, image = cam_video.read()

    # Convert the image into RGB in order to process it
    image_rgb = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
    result = hands.process(image_rgb)

    landmarks_list = []
    total_hands = 0
    open_fingers = []

    if result.multi_hand_landmarks:
        total_hands = len(result.multi_hand_landmarks)

        # Display the landmarks in each hand displayed on the cam
        for hand_landmark in result.multi_hand_landmarks:
            for hand_id, landmarks in enumerate(hand_landmark.landmark):
                height, width, channel = image.shape
                x_coordinate, y_coordinate = int(landmarks.x * width), int(landmarks.y * height)
                landmarks_list.append([hand_id, x_coordinate, y_coordinate])
                draw_media.draw_landmarks(image, hand_landmark, hand_media.HAND_CONNECTIONS)

    if len(landmarks_list) != 0:
        # Check to see if each finger is closed
        for tip_id in range(1, 5):
            if landmarks_list[tips_id[tip_id]][2] < landmarks_list[tips_id[tip_id] - 2][2]:
                open_fingers.append(1)
            else:
                open_fingers.append(0)

        total_fingers = open_fingers.count(1)

        if total_fingers == 4:
            cv2.rectangle(image, (0, 0), (250, 70), (255, 0, 0), cv2.FILLED)
            cv2.putText(image, "Forward", (0, 55), cv2.FONT_HERSHEY_SIMPLEX, 2, (255, 255, 255), 2)

            # Simulate right arrow key press
            press_key(right_key_code)
            right_key_pressed = True
            key_code = right_key_code
            current_key_pressed.add(right_key_code)
            key_pressed = True
            key_count = key_count + 1

        elif total_fingers == 0:
            cv2.rectangle(image, (0, 0), (300, 70), (255, 0, 0), cv2.FILLED)
            cv2.putText(image, "Backward", (0, 55), cv2.FONT_HERSHEY_SIMPLEX, 2, (255, 255, 255), 2)

            # Simulate left arrow key press
            press_key(left_key_code)
            left_key_pressed = True
            key_code = left_key_code
            current_key_pressed.add(left_key_code)
            key_pressed = True
            key_count = key_count + 1

        if total_hands == 2:
            cv2.rectangle(image, (465, 0), (700, 70), (255, 0, 0), cv2.FILLED)
            cv2.putText(image, "Jump", (470, 55), cv2.FONT_HERSHEY_SIMPLEX, 2, (255, 255, 255), 2)

            # Simulate up arrow key press
            press_key(up_key_code)
            release_key(up_key_code)

    # Release the key press if no hand is detected
    if not key_pressed and len(current_key_pressed) != 0:
        for key in current_key_pressed:
            release_key(key)
        current_key_pressed = set()

    # Release the key press when switching keys
    elif key_count == 1 and len(current_key_pressed) == 2:
        for key in current_key_pressed:
            if key_code != key:
                release_key(key)
        current_key_pressed = set()

    cv2.imshow("Frame", image)
    key_pressed = cv2.waitKey(1)

    # Press 'q' key to stop video capture
    if key_pressed == ord('q'):
        break

cam_video.release()
cv2.destroyAllWindows()
