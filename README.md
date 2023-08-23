# Simulink_Unity_Car
## KEB_VectorProject Unity

![Demo_gif](https://github.com/K-Software-BootCamp/2023KEB_Perilla-frutescens/assets/126951066/5434733a-63f1-4d32-b51e-f7695032da83)

- KEB Vector 프로젝트의 차량 시뮬레이터입니다.
- MATLAB/Simulink, CANoe 환경에서 UDP Socket을 통해 작동합니다. 
- 이 시뮬레이터는 실시간 차량 데이터 전송 및 시뮬레이션 환경에서의 인터랙션을 제공합니다.

## 시작하기 전에
이 프로젝트를 사용하기 전에 아래의 필수 요소를 확인하십시오.

- MATLAB 및 Simulink 설치
- UDP 통신 지원을 위한 Simulink 추가 패키지

## 설정 방법
1. Simulink 모델을 열고 UDP Send/Receive 블록을 확인합니다.
2. 필요에 따라 IP 주소 및 포트 번호를 설정합니다. (기본값 127.0.0.1:25000)
3. 모델을 시작하여 시뮬레이션을 실행합니다.

## 통신 세부 사항
- IP 주소: xxx.xxx.xxx.xxx (변경 가능)
- 포트 번호: xxxx
