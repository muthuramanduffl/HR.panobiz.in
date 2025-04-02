<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/supervisor/MasterPage.master" CodeFile="punch-in-out.aspx.cs" Inherits="punch_in_out" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">  
        /* html  
        {  
            height: 100%;  
        }   */
        body  
        {  
            height: 100%;  
            margin: 0;  
            padding: 0;  
        }  
        #MyMapLOC  
        {  
            height: 100%;  
        }  
		#ContentPlaceHolder1_divtogglebtn input {
			cursor: pointer;
		}
        .switch
        {
            position: relative;
            display: inline-block;
            width: 50px;
            height: 24px;
        }
         
        .switch input
        {
            opacity: 0;
        }
         
        .slider
        {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: #ccc;
            -webkit-transition: .4s;
            transition: .4s;
        }
         
        .slider:before
        {
            position: absolute;
            content: "";
            height: 16px;
            width: 16px;
            left: 4px;
            bottom: 4px;
            background-color: white;
            -webkit-transition: .4s;
            transition: .4s;
        }
         
        input:checked + .slider
        {
            background-color: #2196F3;
        }
         
        input:focus + .slider
        {
            box-shadow: 0 0 1px #2196F3;
        }
         
        input:checked + .slider:before
        {
            -webkit-transform: translateX(26px);
            -ms-transform: translateX(26px);
            transform: translateX(26px);
        }
         
        /* Rounded sliders */
        .slider.round
        {
            border-radius: 34px;
        }
         
        .slider.round:before
        {
            border-radius: 50%;
        }


		@media screen and (min-width: 600px) and (max-width: 992px) {
			footer {
				margin-top: auto;
			}
			.employeeDetails-section {
				padding-bottom: 5%;
			}
		}
		footer {
			position: unset !important;
		}
    </style>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <asp:ScriptManager ID="ScriptManager1" runat="server">
 </asp:ScriptManager>

       <div class="text-center text-dark"><br /><asp:Label ID="lblnopunch" runat="server" Text=""></asp:Label></div>
	<div class="employeeDetails-section mt-auto bg-white" id="displaysection" runat="server">
		<div class="col-sm-10 col-lg-5 mx-auto">
			<%--<div class="name-label d-block">
				<h4>
                    <asp:Label ID="lblname" runat="server" Text=""></asp:Label></h4>
				<span><asp:Label ID="lblRole" runat="server" Text=""></asp:Label>  <asp:Label ID="lblclient" runat="server" Text=""></asp:Label></span>
			</div>--%>
			<hr>
			<div class="date-label">
				<!-- <h6>Date</h6> -->
				<div class="date-block my-4">
					<div class="date-field">
						<span id="date"></span>
					</div>
					<div class="vert-line"></div>
					<div class="month-field">
						<span id="month"></span>
					</div>
					<div class="vert-line"></div>
					<div class="day-field">
						<span id="weekday"> </span>
					</div>
				</div>
			</div>
			<hr>
             <asp:Label ID="lbllat" runat="server" Text="" ForeColor="Transparent"></asp:Label>
            <asp:Label ID="lbllong" runat="server" Text="" ForeColor="Transparent"></asp:Label>
        <asp:HiddenField ID = "hdnlat" runat = "server" />
        <asp:HiddenField ID = "hdnlong" runat = "server" />
          <asp:Label ID="Label1" runat="server" Text="" ForeColor="Transparent"></asp:Label>
         <asp:Label ID="Label2" runat="server" Text="" ForeColor="Transparent"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="" ForeColor="Transparent"></asp:Label>

            <asp:HiddenField ID="hdnattendmethod" runat="server" />
            <asp:Label ID="lblnoattend" runat="server" Text=""></asp:Label>
			<div class="name-label punch-section">
				<h6 class="align-self-center" style="display: block;"  id="div_in" runat="server">Punch <span>in</span></h6>
				<h6 class="align-self-center" style="display: none;" id="div_out" runat="server">Punch <span style="background: #b30c0c;">out</span></h6>
				<div class="toggle-btn" id="divtogglebtn" runat="server">
               	<%--<input type="checkbox" class="cb-value" />
                    <span class="round-btn"></span>--%>
                   <%-- <asp:CheckBox ID="chkOnOff" runat="server" CssClass="cb-value" OnCheckedChanged="chkOnOff_Changed" Text="" AutoPostBack="true"/>
                    <span class="round-btn"></span>--%>
				
                <label class="switch">
                    <asp:CheckBox ID="chkOnOff" runat="server" AutoPostBack="true" OnCheckedChanged="chkOnOff_Changed"/>
                    <span class="slider round"></span>
                </label>
                 </div>
			</div>
			<div class="punch-details">
				<div id="div_Attend1">
					<div class="punchIndet" style="display: none;" id="div_Pin1" runat="server"><p><span>Punch in @</span> 
						<asp:Label ID="lblInAttend1" runat="server" Text=""></asp:Label></p></div>
				</div>
				<div id="div_Attend2">
					<div class="punchIndet" style="display: none;" id="div_Pin2" runat="server"><p><span>Punch in @</span> 
						<asp:Label ID="lblInAttend2" runat="server" Text=""></asp:Label></p></div>
				</div>
				<div id="div_Attend3">
					<div class="punchIndet" style="display: none;" id="div_Pout3" runat="server"><p><span>Punch out @</span>
						<asp:Label ID="lblOutAttend3" runat="server" Text=""></asp:Label></p></div>
				</div>
				<div id="div_Attend4">
					<div class="punchIndet" style="display: none;" id="div_Pout4" runat="server"><p><span>Punch out @</span>
						<asp:Label ID="lblOutAttend4" runat="server" Text=""></asp:Label></p></div>
				</div>
				<div id="div_Attend5">
					<div class="punchIndet" style="display: none;" id="div_Pin5" runat="server"><p><span>Punch in @</span> 
						<asp:Label ID="lblInAttend5" runat="server" Text=""></asp:Label></p></div>
					<div class="punchIndet" style="display: none;" id="div_Pout5" runat="server"><p><span>Punch out @</span>
						<asp:Label ID="lblOutAttend5" runat="server" Text=""></asp:Label></p></div>
				</div>
				<div id="div_Attend6">
					<div class="punchIndet" style="display: none;" id="div_Pin6" runat="server"><p><span>Punch in @</span> 
						<asp:Label ID="lblInAttend6" runat="server" Text=""></asp:Label></p></div>
					<div class="punchIndet" style="display: none;" id="div_Pout6" runat="server"><p><span>Punch out @</span>
						<asp:Label ID="lblOutAttend6" runat="server" Text=""></asp:Label></p></div>
				</div>
			</div>
            
              <div class="text-center">
				<asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Black"></asp:Label>
			  </div>
		</div>
	</div>
	<!--======== END: EMPLOYEE DETAILS ========-->
         <asp:Label ID="lblno" runat="server" Text="" ForeColor="Black"></asp:Label>
    <div class="submit-report-btn" style="display: none;" runat="server" id="submitbtn">
	    <input type="button" class="btn" onclick="window.location.href='addactivity.aspx'" value="Submit Activity Report">
    </div>             <div id="MyMapLOC" style="width: 550px; height: 470px;display: none;">  
    </div> 

	<!--   Core JS Files   -->
	<script src="../assets/js/core/jquery.3.2.1.min.js"></script>
	<script src="../assets/js/core/popper.min.js"></script>
	<script src="../assets/js/core/bootstrap.min.js"></script>

	<!-- jQuery UI -->
	<script src="../assets/js/plugin/jquery-ui-1.12.1.custom/jquery-ui.min.js"></script>
	<script src="../assets/js/plugin/jquery-ui-touch-punch/jquery.ui.touch-punch.min.js"></script>

	<!-- jQuery Scrollbar -->
	<script src="../assets/js/plugin/jquery-scrollbar/jquery.scrollbar.min.js"></script>


	<!-- Chart JS -->
	<script src="../assets/js/plugin/chart.js/chart.min.js"></script>

	<!-- jQuery Sparkline -->
	<script src="../assets/js/plugin/jquery.sparkline/jquery.sparkline.min.js"></script>

	<!-- Chart Circle -->
	<script src="../assets/js/plugin/chart-circle/circles.min.js"></script>

	<!-- Datatables -->
	<script src="../assets/js/plugin/datatables/datatables.min.js"></script>

	<!-- Bootstrap Notify -->
	<script src="../assets/js/plugin/bootstrap-notify/bootstrap-notify.min.js"></script>

	<!-- jQuery Vector Maps -->
	<script src="../assets/js/plugin/jqvmap/jquery.vmap.min.js"></script>
	<script src="../assets/js/plugin/jqvmap/maps/jquery.vmap.world.js"></script>

	<!-- Sweet Alert -->
	<script src="../assets/js/plugin/sweetalert/sweetalert.min.js"></script>

	<!-- Atlantis JS -->
	<script src="../assets/js/atlantis.min.js"></script>
	<script>
		

		//today's date
		var today = new Date();
		$('#weekday').html(today.toDateString().substring(0,3));
		$('#date').html( today.getDate() );

		var month = today.getMonth();
		var monthNames = [ "Jan", "Feb", "Mar", "Apr", "May", "Jun",
    	"Jul", "Aug", "Sep", "Oct", "Nov", "Dec" ];
		document.getElementById("month").innerHTML = monthNames[month];

		//toggle button
		// 	$('.toggle-btn').click(function() {
		// 	var mainParent = $(this).parent('.toggle-btn');
		// 	if($(mainParent).find('input#chkOnOff').is(':checked')) {
		// 		$(mainParent).addClass('active');
		// 	}
		// });

		$('.toggle-btn').click(function() {
			if($('.toggle-btn').find('input#chkOnOff').is(':checked')) {
				$(this).addClass('active');
			} else {
				$(this).removeClass('active');
			}
		});
		//$('.cb-value').click(function() {
		//	var mainParent = $(this).parent('.toggle-btn');
		//	if($(mainParent).find('input.cb-value').is(':checked')) {
		//		$(mainParent).addClass('active');
		//		//$('.punchIn').hide();
		//		//$('.punchOut').show();
		//		//$('.punchIndet').show();

		//		//Notify 
		//		// var placementFrom = $('#notify_placement_from option:selected').val();
		//		// var placementAlign = $('#notify_placement_align option:selected').val();
		//		// var state = $('#notify_state option:selected').val();
		//		// var style = $('#notify_style option:selected').val('withicon');
		//		var content = {};

		//		content.message = ' ';
		//		content.title = 'Have a Nice Day!';
				
		//		$.notify(content,{
		//			type: 'primary',
		//			placement: {
		//				from: 'bottom',
		//				align: 'center'
		//			},
		//			mouse_over: null,
		//			animate: {
		//				enter: 'animated fadeInUp',
		//				exit: 'animated fadeOutRight'
		//			},
		//			onShow: null,
		//			onShown: null,
		//			onClose: null,
		//			onClosed: null,
		//			time: 1000,
		//			delay: 2000,
		//		});


		//	} else {
		//		$(mainParent).removeClass('active');
		//		//$('.punchIn').show();
		//		//$('.punchOut').hide();
		//		//$('.punchOutdet').show();
		//		//$('.punch-section').fadeOut();
		//		//$('.submit-report-btn').show();
		//	}
		//})

		
		$(document).ready(function() {
		var monthNames = [ "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" ]; 

		var newDate = new Date();
		newDate.setDate(newDate.getDate());
		$('#Date').html([newDate.getDate()] + ' ' + monthNames[newDate.getMonth()] + ', ' + newDate.getFullYear());
		
		setInterval( function() {
		var seconds = new Date().getSeconds();
		$("#sec").html(( seconds < 10 ? "0" : "" ) + seconds);
		},1000);
		
		setInterval( function() {
		var minutes = new Date().getMinutes();
		$("#min").html(( minutes < 10 ? "0" : "" ) + minutes);
		},1000);
		
		setInterval( function() {
		var hours = new Date().getHours();
		$("#hours").html(( hours < 10 ? "0" : "" ) + hours);
		}, 1000); 
		});
	</script>

        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk&sensor=false">  
    </script>  
  
    <!-- <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false&libraries=places">  
    </script>   -->
  
    <script type="text/javascript">  
        if (navigator.geolocation) {  
            navigator.geolocation.getCurrentPosition(success);  
        } else {  
        alert("There is Some Problem on your current browser to get Geo Location!");  
        }  
  
        function success(position) {  
            var lat = position.coords.latitude;  
            var long = position.coords.longitude;  
            var city = position.coords.locality;  
            var LatLng = new google.maps.LatLng(lat, long);  
            var mapOptions = {  
                center: LatLng,  
                zoom: 12,  
                mapTypeId: google.maps.MapTypeId.ROADMAP  
            };  
  
            var map = new google.maps.Map(document.getElementById("MyMapLOC"), mapOptions);  
            var marker = new google.maps.Marker({  
                position: LatLng,  
                title: "<div style = 'height:60px;width:200px'><b>Your location:</b><br />Latitude: "   
                            + lat + +"<br />Longitude: " + long  
           });  
           
            document.getElementById("<%=lbllat.ClientID %>").innerHTML = lat;
            document.getElementById("<%=hdnlat.ClientID %>").value = document.getElementById("<%=lbllat.ClientID %>").innerHTML;
            document.getElementById("<%=lbllong.ClientID %>").innerHTML = long;
            document.getElementById("<%=hdnlong.ClientID %>").value = document.getElementById("<%=lbllong.ClientID %>").innerHTML;
            marker.setMap(map);  
            var getInfoWindow = new google.maps.InfoWindow({ content: "<b>Your Current Location</b><br/> Latitude:" +   
                                    lat + "<br /> Longitude:" + long + "" });  
            getInfoWindow.open(map, marker);  
        }  
    </script>  
</asp:Content>