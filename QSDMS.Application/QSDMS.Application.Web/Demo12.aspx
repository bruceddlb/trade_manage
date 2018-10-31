<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�������������ݽӿ�</title>
    <script type="text/javascript" src="http://api.map.baidu.com/api?key=59db371659c04947a1ff044e80565718&v=1.1&services=true">
    </script>
    <script src="Content/scripts/jquery/jquery-2.0.3.min.js"></script>
</head>
<body>
    lng:<input id="text1" type="text" value="" />
    lat:<input id="text2" type="text" value="" />
    <input id="btn" type="button" value="��ѯ" />
    <input id="text3" type="text" value="�����Ƽ�" />
    <input id="btn1" type="button" value="��ַ��ѯ" />

    <div style="width: 520px; height: 200px; border: 1px solid gray" contenteditable="true" id="info"></div>
    <div style="width: 800px; height: 500px; border: 1px solid gray" id="container">
    </div>

</body>
</html>
<script type="text/javascript">

    var map = new BMap.Map("container");
    map.centerAndZoom(new BMap.Point(121.528599, 31.217681), 12);
    //map.centerAndZoom(new BMap.Point(114.309531, 30.59619), 50);
    //���ؼ���ӵ���ͼ��һ���ؼ�ʵ��ֻ�����ͼ�����һ��  
    map.addControl(new BMap.MapTypeControl());
    //���õ�ͼ��ʾ�ĳ��У�Ĭ��Ϊ�人  
    map.setCurrentCity("�˲�");
    //map.centerAndZoom('�˲���Ҹ�', 11);
    //map.addControl(new BMap.ScaleControl());
    //map.addControl(new BMap.OverviewMapControl());
    //var ctrl_nav = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
    //map.addControl(ctrl_nav);

    //map.enableDragging(); //���õ�ͼ��ק�¼���Ĭ������(�ɲ�д)
    //map.enableScrollWheelZoom(); //���õ�ͼ���ַŴ���С
    //map.enableDoubleClickZoom(); //�������˫���Ŵ�Ĭ������(�ɲ�д)
    //map.enableKeyboard(); //���ü����������Ҽ��ƶ���ͼ


    map.addEventListener("click", function () {
        var center = map.getCenter();
        document.getElementById("info").innerHTML = center.lng + ", " + center.lat;
    });

    // ��д�Զ��庯����������ע   
    function addMarker(point) {

        // ����ͼ�����   
        var myIcon = new BMap.Icon("http://api.map.baidu.com/img/markers.png", new BMap.Size(23, 25), {
            // ָ����λλ�á�   
            // ����ע��ʾ�ڵ�ͼ��ʱ������ָ��ĵ���λ�þ���ͼ������   
            // �Ǹ�ƫ��10���غ�25���ء������Կ����ڱ����и�λ�ü���   
            // ͼ�������¶˵ļ��λ�á�   
            offset: new BMap.Size(10, 25),
            // ����ͼƬƫ�ơ�   
            // ������Ҫ��һ���ϴ��ͼƬ�н�ȡĳ������Ϊ��עͼ��ʱ����   
            // ��Ҫָ����ͼ��ƫ��λ�ã���������css sprites�������ơ�   
            imageOffset: new BMap.Size(0, 0 - 1 * 25)   // ����ͼƬƫ��   
        });

        // ������ע������ӵ���ͼ   
        var marker = new BMap.Marker(point);
        map.addOverlay(marker);

        //�Ƴ���ע
        marker.addEventListener("click", function () {
            //            map.removeOverlay(marker);
            //            marker.dispose();

            var opts = {
                width: 250,     // ��Ϣ���ڿ��
                height: 100,     // ��Ϣ���ڸ߶�
                title: "lng:" + point.lng + "lat:" + point.lat  // ��Ϣ���ڱ���
            }

            var infoWindow = new BMap.InfoWindow("", opts);  // ������Ϣ���ڶ���
            marker.openInfoWindow(infoWindow, this.point);      // ����Ϣ����

        });
    }


    $(document).ready(function () {
        $("#btn").click(function () {
            //var point = new BMap.Point(parseFloat($("#text1").val()) + 0.0065, parseFloat($("#text2").val()) + 0.0065);
            //var point = new BMap.Point(parseFloat($("#text1").val()), parseFloat($("#text2").val()));
            var point = new BMap.Point(121.528599, 31.217681);
            alert(point);
            addMarker(point);
        });
        $("#btn1").click(function () {
            document.getElementById("info").innerHTML = "";
            var LocalSearch = new BMap.LocalSearch(map, {
                renderOptions: { map: map }
            });
            LocalSearch.search($("#text3").val());
            LocalSearch.setSearchCompleteCallback(function () {
                var item = LocalSearch.getResults();
                for (var i = 0; i < item.getNumPois() ; i++) {
                    var LocalResultPoi = item.getPoi(i);
                    if (LocalResultPoi) {
                        var point = new BMap.Point((LocalResultPoi.point.lat), (LocalResultPoi.point.lng));
                        // alert(point)
                        addMarker(point);
                    }
                    document.getElementById("info").innerHTML = document.getElementById("info").innerHTML + LocalResultPoi.title + "," + LocalResultPoi.point.lat + "," + LocalResultPoi.point.lng + LocalResultPoi.address + "<br>";
                }
            });


        });

    });

</script>

