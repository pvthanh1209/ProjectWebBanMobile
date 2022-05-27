//Auto slider banner Trang chủ
var index;
setInterval(function () {
    index = parseInt(document.querySelector('input[name="radio-btn"]:checked').value);
    index++;
    if (index > 4) {
        index = 1;
    }
    document.getElementById('radio' + index).checked = true;
}, 4000);

//Xử lý sự kiện khi nhấn nút Enter phần bình luận Chi tiết sản phẩm
function Trig() {
    var input = document.querySelector(".txtComment");
    if (window.event.keyCode == 13) {
        document.querySelector(".btnCmt").focus();
    }
}

//Sư kiện button tăng giảm số lượng mua sản phẩm
var i = 1;
function incProduct(obj) {
    if (i < 10) {
        i++;
    } else if (i = 10) {
        i = 0;
    }
    obj.previousSibling.value = i;
}

function decProduct(obj) {
    if (i > 0) {
        --i;
    } else if (i <= 0) {
        i = 10;
    }
    obj.nextSibling.value = i;
}
// Sự kiện button tăng giảm số lượng mua ở giỏ hàng
function tang(obj) {
    var current = obj.previousSibling.value;
    if (current < 10) {
        current++;
    } else if (current = 10) {
        current = 0;
    }
    obj.previousSibling.value = current;
}

function giam(obj) {
    var txtSL = obj.nextSibling.value;
    if (txtSL > 0) {
        --txtSL;
    } else if (txtSL <= 0) {
        txtSL = 10;
    }
    obj.nextSibling.value = txtSL;
}
//Định dạng ngày phần bình luận
function dinhdang(date) {
    var arr = date.split("-");
    var nam = arr[0];
    var thang = arr[1];
    var thoigian = arr[2].split("T");
    var ngay = thoigian[0];
    var giophut = thoigian[1].substring(0, 5);
    date = ngay + "/" + thang + "/" + nam + " " + giophut;
    return date;

}
function napDanhsachUser(id) {
    var d2;
    var xhttp, xmlDoc, x, i;
    xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        var div = document.getElementById('myListview');
        var domParser = new DOMParser();
        xmlDoc = domParser.parseFromString(xhttp.responseText, "application/xml");
        var x = xmlDoc.getElementsByTagName("Table");
        var html = "";
        for (var i = 0; i < x.length; i++) {
            html += "<div class= \"user\">";
            html += "<span id=\"Username\" class=\"username\">" + x[i].childNodes[1].textContent + "</span>";
            html += "<span id=\"Comments\">" + x[i].childNodes[3].textContent + "</span>";
            d2 = String(x[i].childNodes[5].textContent);
            html += "<span  id=\"Label1\" class=\"time-cmt\">" + "User trong web" + dinhdang(d2) + "</span>";
            console.log(typeof d2);
            html += "</div>";
        }
        div.innerHTML = html;
        var lv = document.getElementById('listview');
        var elems = document.getElementsByClassName('btnMore');
        var taptrung = document.getElementById('test');
        lv.style.display = 'none';
        taptrung.style.visibility = 'hidden';
    }
    xhttp.open("GET", "Quanlyuser?act=lay&sUserName=" + id, true);
    xhttp.send();

}
function themCmt(idSP) {

    var binhluan = document.getElementsByClassName('txtComment');
    var xhttp = new XMLHttpRequest();
    if (binhluan[0].value == "") {
        alert("Bạn chưa nhập bình luận");
    }
    else {
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                var domParser = new DOMParser();
                xmlDoc = domParser.parseFromString(this.responseText, "application/xml");
                napDanhsachDanhgia(idSP);
                binhluan[0].value = "";
            }
        };
        xhttp.open("POST", "Quanlyuser.aspx?act=them&=sUserName" + idSP, true);
        xhttp.send();
    }
}
