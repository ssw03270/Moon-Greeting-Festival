<a name="readme-top"></a>
# Moon-Greeting-Festival
가상현실을 이용해 한국 민속촌 마을에서 즐기는 축제 체험

<!-- TABLE OF CONTENTS -->
<details>
  <summary>목차</summary>
  <ol>
    <li>
      <a href="#about-the-project">About the Project</a>
      <ul>
        <li><a href="#built-with">Built with</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#application-contents">Application Contents</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

# About the Project

<h4 align="center">한국 민속촌 체험의 강점과 약점 파악 <br/></h4>

- 사용자가 직접 상호작용하고 컨텐츠에 참여하는 방식인 '축제 체험'과 관련된 컨텐츠를 생각하던 중 한국 민속촌 체험을 떠올리게 됨.
- 한국 고유의 정서와 생활방식을 담은 민속촌은 실제 관광지로도 여럿 있을만큼 볼거리와 즐길거리가 풍부하지만, 현대인들은 '축제’ 라고 하면 
놀이공원과 같은 콘텐츠를 먼저 떠올리는 경향이 있음.

<h4 align="center">민속촌과 가상현실의 접목 <br/></h4>

- 민속촌과 가상현실 기술을 접목시켜, 가상현실의 장점을 극대화하면서 전통 문화에 쉽게 접근할 수 있게됨으로써 기존 민속촌이 가지던 해당 약점을 보완시키며 서로의 장점을 극대화시킬 수 있다고 생각하여 주제를 도출하게됨.

## Built with
* [![Unity][Unity]][Unity-url] **(2021.3.11f1 LTS)**
* [![Oculus][Oculus]][Oculus-url]
* [![C#][C#]][C#-url]
* [![Visual Studio][Visual Studio]][VS-url]
* [![Github][Github]][Github-url]

# Getting Started

## Prerequisites
1. Build를 진행하는 PC에 Unity Editor, Android SDK, Android NDK, Java JDK를 설치한다. 
2. Unity 내에서 Files > Build Setting을 선택한 뒤, Android로 Platform을 변경한다. <br/>
   (Texture Compression 세팅은 'ASTC', Compression Method 세팅은 'LZ4'로 설정한다.)
3. Oculus Quest 2를 USB-C 케이블을 이용해 PC와 연결한다.
4. Player > Other Settings에서 
    1. Package 이름을 설정한다.
    2. Rendering 설정에서 Auto Graphic API를 체크 표시한다.
    3. Android Minimum API를 23 이상으로 설정한다.
5. Project Settings > XR Plug-in Management에서 Oculus를 체크한다. <br/>
   만일 세팅에 위 항목이 존재하지 않는다면 먼저 XR Plugin Management을 설치하여야 한다. 

## Installation
1. 본 프로젝트 Repository를 Fork한 뒤 Local Directory에 Clone한다.
2. 위 Prerequisites 사항을 체크한다.
3. Build Settings > Android > Run Device에서 앱을 실행할 Oculus Quest 2 기기를 선택한다.
4. 3번의 화면에서 Build Button을 클릭해 Apk 파일을 생성한다.
5. 생성된 Apk 파일을 Oculus Developer Hub의 UNKNOWN SOURCES(알수없는 출처)에 드래그하여 설치한다.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

# Application Contents
1. 가상에 구현된 전통 마을 <br/>
a. 플레이어가 활동하게 될 전통 마을은 다양한 전통 건물과 구조물로 구성되어 있다. <br/>
b. 각 건물에는 플레이어가 체험할 수 있는 전통 놀이와 문화가 존재한다. <br/>
2. VR을 이용한 전통 놀이와 문화 체험하기 <br/>
a. 플레이어는 VR 장비를 착용한 채 위 사진 속 마을을 돌아다닐 수 있다. <br/>
b. 자신이 원하는 건물에 들어가 각 건물에 비치된 전통 놀이와 문화를 체험하는 것이 가능하다. <br/>

|분야| 이름 | 설명 |
|---|---|---|
|전통 놀이|투호 놀이|화살을 병 속에 던져 넣은 후에 그 수효로써 승부를 결정한다.|
|전통 놀이|연날리기|연에 보통 글을 써서 연실을 끊어 멀리 날려보낸다.|
|전통 놀이|전통 활쏘기|사대에 서서 두 팔로 전통 활과 화살을 이용하여 과녁에 맞춘다.|
|전통 놀이|쥐불 놀이|논이나 밭두렁에 불을 붙이는 정월의 민속놀이다.|
|전통 문화|곤장 체험|죄인을 묶어 놓고 집행하던 형벌에 사용된 형구 체험하기|
|전통 문화|뒤주 체험| 뒤주 속에  갇혀보는 체험하기|
|전통 문화|사물놀이 체험|사물(꽹과리, 징, 장구, 북)을 중심으로 연주 체험하기|

<p align="right">(<a href="#readme-top">back to top</a>)</p>



# Contact
| 학교     |팀원          |역할       |이메일                     |
|:--------|:------------|:---------|:------------------------|
| 경희대학교 | 김민정       | 프로그래머   |san012@khu.ac.kr|
| 경희대학교 | 서승원       | 프로그래머    |ssw03270@khu.ac.kr |

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES -->

[Unity]: https://img.shields.io/badge/Unity-000000?style=for-the-badge&logo=Unity&logoColor=white
[Unity-url]: https://unity.com/
[C#]:https://img.shields.io/badge/C%20Sharp-239120?style=for-the-badge&logo=C%20sharp&logoColor=white
[C#-url]: https://en.wikipedia.org/wiki/C_Sharp_(programming_language)
[Oculus]: https://img.shields.io/badge/Oculus-1C1E20?style=for-the-badge&logo=Oculus&logoColor=white
[Oculus-url]: https://www.oculus.com/experiences/quest/
[Visual Studio]: https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=Visual%20Studio&logoColor=white
[VS-url]: https://visualstudio.microsoft.com/ko/
[Github]: https://img.shields.io/badge/Github-5C2D91?style=for-the-badge&logo=Github&logoColor=white
[Github-url]: https://github.com/ssw03270/Moon-Greeting-Festival
