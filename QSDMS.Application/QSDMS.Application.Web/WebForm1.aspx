<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="QSDMS.Application.Web.WebForm1" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
   
  
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=ptxzkrdeSbMUbBWGLHHd6gwZhQ3KkqSl"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="control-group">
        <label class="control-label">��ϸ��ַ��</label>
        <div class="controls">
            <input type="text" id="addr" value="" name="detil_addr" />
            <input type="button" value="�����λ" style="width: 100px;" class="NFButton" onclick="dingwei()">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
        </div>
    </div>
    <div class="control-group">
        <label class="control-label">��γ�ȣ�</label>
        <div class="controls">
            <input type="text" name="point_x" id="lng" size="15" onkeypress="if(event.keyCode == 13) return false;">
            <input type="text" name="point_y" id="lat" size="15" onkeypress="if(event.keyCode == 13) return false;">
            <input type="hidden" id="zoom" name="zoom" value="15" size="5">
        </div>
    </div>

    <!-- ��ͼ������ -->
    <div id="content" style="width: 95%; height: 404px; margin: 0 auto; border: 1px solid #d3d3d3;">
        <div style="float: left; height: 400px; width: 100%; display: -webkit-box; overflow: hidden;" id="l-map"></div>
    </div>
    <div class="clear"></div>
    <!-- ��ͼ������ -->
    </form>
</body>
</html>

<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=ptxzkrdeSbMUbBWGLHHd6gwZhQ3KkqSl"></script>
 <%--<script type="text/javascript">

     (function () {        //�հ�
         function load_script(xyUrl, callback) {
             var head = document.getElementsByTagName('head')[0];
             var script = document.createElement('script');
             script.type = 'text/javascript';
             script.src = xyUrl;
             //�����jQuery��script���򷽷�
             script.onload = script.onreadystatechange = function () {
                 if ((!this.readyState || this.readyState === "loaded" || this.readyState === "complete")) {
                     callback && callback();
                     // Handle memory leak in IE
                     script.onload = script.onreadystatechange = null;
                     if (head && script.parentNode) {
                         head.removeChild(script);
                     }
                 }
             };
             // Use insertBefore instead of appendChild  to circumvent an IE6 bug.
             head.insertBefore(script, head.firstChild);
         }
         function translate(point, type, callback) {
             var callbackName = 'cbk_' + Math.round(Math.random() * 10000);    //���������
             var xyUrl = "http://api.map.baidu.com/ag/coord/convert?from=" + type + "&to=4&x=" + point.lng + "&y=" + point.lat + "&callback=BMap.Convertor." + callbackName;
             //��̬����script��ǩ
             load_script(xyUrl);
             BMap.Convertor[callbackName] = function (xyResult) {
                 delete BMap.Convertor[callbackName];    //��������Ҫɾ���ĺ���
                 var point = new BMap.Point(xyResult.x, xyResult.y);
                 callback && callback(point);
             }
         }

         window.BMap = window.BMap || {};
         BMap.Convertor = {};
         BMap.Convertor.translate = translate;
     })();

    </script>--%>

<script type="text/javascript">

    var cityName = "������";
    var desAddress = "������";
    var p2;
    function addMarker(point, obj, p1) {
        var opt = { "title": "", "enableDragging": true };
        var marker = new BMap.Marker(point, opt);
        map.addOverlay(marker);
        marker.addEventListener("mouseup", function (e1) {          
            a(e1.point);
        });

    }

    // �ٶȵ�ͼAPI����    new BMap.Point(120.204, 33.3)
    var map = new BMap.Map("l-map");
    var dbx = "120.137034";
    var dby = "30.280934";
    var dbz = 12;

    if (dbx && dby && dbz) {
        map.centerAndZoom(new BMap.Point(dbx, dby), 12);
        addMarker(new BMap.Point(dbx, dby));
    } else {

        var myGeo = new BMap.Geocoder();
        myGeo.getPoint(desAddress, function (point) {
            if (point) {
                p2 = point;
                map.centerAndZoom(p2, 12);
            }
            else {
                alert("�Բ��𣬻�ȡ��������λ�ã�")
            }
        }, cityName);
    }


    map.addEventListener("click", function (e) {
        //        alert(e.point.lng + " " + e.point.lat);
        a(e.point);
    });

    function a(pp) {
        var x = pp.lng
        var y = pp.lat
        document.getElementById('lng').value = "" + x + ""; //����
        document.getElementById('lat').value = "" + y + ""; //ά��
        document.getElementById('zoom').value = "" + map.getZoom() + "";
        map.clearOverlays();
        addMarker(new BMap.Point(x, y));
    }


    //map.addControl(new BMap.NavigationControl());
    //map.enableScrollWheelZoom(true);


    //var options = {
    //    renderOptions: { map: map, autoViewport: true },

    //    onSearchComplete: function (results) {
    //        if (driving.getStatus() == BMAP_STATUS_SUCCESS) {
    //            // ��ȡ��һ������
    //            var plan = results.getPlan(0);

    //            // ��ȡ�����ļݳ���·
    //            var route = plan.getRoute(0);

    //            // ��ȡÿ���ؼ�����,�������ҳ��
    //            var s = [];
    //            for (var i = 0; i < route.getNumSteps() ; i++) {
    //                var step = route.getStep(i);
    //                s.push((i + 1) + ". " + step.getDescription());
    //            }
    //            //document.getElementById("r-result").innerHTML = s.join("<br/>");
    //        }
    //    }
    //};



    //var x = document.getElementById("demox");

    //var p1;
    //function showPosition(position) {

    //    BMap.Convertor.translate(new BMap.Point(position.coords.longitude, position.coords.latitude), 0, function (point) {
    //        //marker.setPosition(point);
    //        map.panTo(point);
    //        p1 = point;
    //        //var driving = new BMap.DrivingRoute(map, {renderOptions:{map: map, autoViewport: true}});
    //        driving.search(p1, p2);
    //    });
    //}

    function dingwei() {
        var adr = document.getElementById('addr').value;
        if (adr == '') {
            alert('��������ȷ��ַ');
            document.getElementById('addr').focus();
            return;
        }
        var myGeo = new BMap.Geocoder();
        myGeo.getPoint(adr, function (point) {
            if (point) {
                p2 = point;
                map.centerAndZoom(p2, 13);
                map.clearOverlays();
                addMarker(p2);
                document.getElementById('lng').value = "" + point.lng + "";
                document.getElementById('lat').value = "" + point.lat + "";
            }
            else {
                alert("�Բ����Զ���λ��ʽ��ȡ��������λ�ã�")
            }
        }, cityName);

    }

</script>