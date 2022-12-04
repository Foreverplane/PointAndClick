# PointAndClick

На разработку потрачено ~ 12 часов. Около половины из которого на имитацию клиент-серверности приложения.

<img src="https://user-images.githubusercontent.com/28690609/205513945-91be4920-aad1-4036-9d63-9c19e8fbba4f.png" width=50% height=50%>


Всё что находится в этих (скриншот ниже) сборках подразумевает возможность запуска на "сервере". В сборке Shared - лежит всё что можно запускать и на клиенте и на сервере. 

![image](https://user-images.githubusercontent.com/28690609/205514356-176b44cf-63d1-4a1a-8a0a-74cba2fd267b.png)

Здесь на клиенте имитируются серверные системы:

![image](https://user-images.githubusercontent.com/28690609/205515511-8d28010a-6b41-4468-91ef-5a329534984b.png)


Чтобы можно было это протестить через компилируемость консольного приложения здесь лежит солюшен для консольного приложения.

![image](https://user-images.githubusercontent.com/28690609/205514440-4712207f-c0a8-4230-9585-c1f75bfdbe97.png)

После запуска псевдо сервер начнёт тикать.

![image](https://user-images.githubusercontent.com/28690609/205514557-8ba84c43-fed8-4c18-a066-a5284c611512.png)

Зависимости с LeoEcsLite, ZenjectNonUnity, Unity.Mathematics прописаны и протестированы.

На всякий случай:  
LeoEcsLite - для сервера установлен из нюгетов  
ZenjectNonUnity - PointAndClick/Server/ZenjectNonUnity/  
Unity.Mathematics - достал из редактора и положил сюда PointAndClick/Server/  

Примечание к Unity.Mathematics.

Несмотря на то, что в задании было указано что можно пользоваться Vector3 и прочим - вместо UnityEngine.dll (где они находятся в Unity 2021.3) - использовал Unity.Mathematics.dll т.к. если дать ссылку на UnityEngine.dll в серверную часть, то проверить с помощью компилируемости использованы ли там другие компоненты кроме Vector3 не представил возможным. 

Ps:
Запуск в редакторе юнити со сцены SampleScene.

