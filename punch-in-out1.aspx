 <%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage-new.master" CodeFile="punch-in-out1.aspx.cs" Inherits="punch_in_out" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">  
        html  
        {  
            height: 100%;  
        }  
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

		.min-height-50vh {
			min-height: 70vh;
		}
		footer {
			position: unset !important;
		}
    </style>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <asp:ScriptManager ID="ScriptManager1" runat="server">
 </asp:ScriptManager>

 <div class="min-height-50vh">
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
		<asp:HiddenField ID="hdnEmpId" runat="server" />
		<asp:HiddenField ID="hdnGeofenceStatus" runat="server" />
          <asp:Label ID="Label1" runat="server" Text="" ForeColor="Transparent"></asp:Label>
         <asp:Label ID="Label2" runat="server" Text="" ForeColor="Transparent"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="" ForeColor="Transparent"></asp:Label>

            <asp:HiddenField ID="hdnattendmethod" runat="server" />
            <asp:Label ID="lblnoattend" runat="server" Text=""></asp:Label>
			<div class="name-label punch-section" id="punchDetails" style="display: none;">
				<h6 class="align-self-center" style="display: block;"  id="div_in" runat="server">Punch <span>in</span></h6>
				<h6 class="align-self-center" style="display: none;" id="div_out" runat="server">Punch <span style="background: #b30c0c;">out</span></h6>
				<div class="toggle-btn" id="divtogglebtn" runat="server">
               	<%--<input type="checkbox" class="cb-value" />
                    <span class="round-btn"></span>--%>
                   <%-- <asp:CheckBox ID="chkOnOff" runat="server" CssClass="cb-value" OnCheckedChanged="chkOnOff_Changed" Text="" AutoPostBack="true"/>
                    <span class="round-btn"></span>--%>
				
                <label class="switch" id="locationEnabledDiv" style="display: none;">
                    <asp:CheckBox ID="chkOnOff" runat="server" AutoPostBack="true" OnCheckedChanged="chkOnOff_Changed"/>
                    <span class="slider round"></span>
                </label>
                 </div>
			</div>


			<div id="geofenceoutside" style="display: none; color: black;">
				<p style="text-align: center; font-size: 17px;">
					You can't punch in attendance outside Geofence. 
				</p>
			</div>

<!--======== DIV : LOCATION ENABLE ALERT ========-->


<div id="locationDeniedMessage" style="display: none;">
	<p>Please turn on the location services in your mobile to procced with punch in / out.</p>
  </div>


			<div class="punch-details" >
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
</div>


 <!--======== POPUP : LOCATION ENABLE ALERT ========--> 
<div class="modal fade" id="locationDeniedModal" tabindex="-1" role="dialog" aria-labelledby="locationDeniedModalLabel" aria-hidden="true">
	<div class="modal-dialog" role="document">
	  <div class="modal-content">
		<div class="modal-header">
		  <h5 class="modal-title" id="locationDeniedModalLabel">Location Services Disabled</h5>
		  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
			<span aria-hidden="true">&times;</span>
		  </button>
		</div>
		<div class="modal-body">
		  Please enable location services to use this feature.
		</div>
		<div class="modal-footer">
		  <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
		</div>
	  </div>
	</div>
  </div>

	<!--   Core JS Files   -->
	<script src="assets/js/core/jquery.3.2.1.min.js"></script>
	<script src="assets/js/core/popper.min.js"></script>
	<script src="assets/js/core/bootstrap.min.js"></script>

	<!-- jQuery UI -->
	<script src="assets/js/plugin/jquery-ui-1.12.1.custom/jquery-ui.min.js"></script>
	<script src="assets/js/plugin/jquery-ui-touch-punch/jquery.ui.touch-punch.min.js"></script>

	<!-- jQuery Scrollbar -->
	<script src="assets/js/plugin/jquery-scrollbar/jquery.scrollbar.min.js"></script>


	<!-- Chart JS -->
	<script src="assets/js/plugin/chart.js/chart.min.js"></script>

	<!-- jQuery Sparkline -->
	<script src="assets/js/plugin/jquery.sparkline/jquery.sparkline.min.js"></script>

	<!-- Chart Circle -->
	<script src="assets/js/plugin/chart-circle/circles.min.js"></script>

	<!-- Datatables -->
	<script src="assets/js/plugin/datatables/datatables.min.js"></script>

	<!-- Bootstrap Notify -->
	<script src="assets/js/plugin/bootstrap-notify/bootstrap-notify.min.js"></script>

	<!-- jQuery Vector Maps -->
	<script src="assets/js/plugin/jqvmap/jquery.vmap.min.js"></script>
	<script src="assets/js/plugin/jqvmap/maps/jquery.vmap.world.js"></script>

	<!-- Sweet Alert -->
	<script src="assets/js/plugin/sweetalert/sweetalert.min.js"></script>

	<!-- Atlantis JS -->
	<script src="assets/js/atlantis.min.js"></script>
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
		//		$('.punchIn').hide();
		//		$('.punchOut').show();
		//		$('.punchIndet').show();

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
		//		$('.punchIn').show();
		//		$('.punchOut').hide();
		//		$('.punchOutdet').show();
		//		$('.punch-section').fadeOut();
		//		$('.submit-report-btn').show();
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
  
  <script>
	

		// function imageUpl() {
        
    // }
		</script>




    <!-- <script type="text/javascript">  
        if (navigator.geolocation) {  
            navigator.geolocation.getCurrentPosition(success);  
        } else {  
        alert("There is some problem on your current browser to get Geo Location!");  
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
            //alert(document.getElementById("<%=lbllat.ClientID %>").innerHTML);
            document.getElementById("<%=hdnlat.ClientID %>").value = document.getElementById("<%=lbllat.ClientID %>").innerHTML;
            document.getElementById("<%=lbllong.ClientID %>").innerHTML = long;
            document.getElementById("<%=hdnlong.ClientID %>").value = document.getElementById("<%=lbllong.ClientID %>").innerHTML;
            marker.setMap(map);  
            var getInfoWindow = new google.maps.InfoWindow({ content: "<b>Your Current Location</b><br/> Latitude:" +   
                                    lat + "<br /> Longitude:" + long + "" });  
            getInfoWindow.open(map, marker);  
        }   -->

<!-- //function fileValidation(id, errlbl) { 
//    var fileInput =  document.getElementById(id); 
//    var filePath = fileInput.value; 
      
//    // Allowing file type 
//    var files = fileInput.files;
//    var file = files[0];
//    var size = parseFloat(files[0].size / 1024).toFixed(2);
//            var r = (size / 1024).toFixed(2);
            
//    if (r > 5) {
//        document.getElementById(errlbl).style.display = "block";
//        document.getElementById("hdnflag").value = "1";
//        return false; 
//    }
//    else {
//        document.getElementById(errlbl).style.display = "none";
//        document.getElementById("hdnflag").value = "0";
//         return true; 
//    }
//}  -->
    <!-- </script>   -->

	<!-- <script type="text/javascript">
		window.onload = function() {
			checkLocationPermission();
		};
	</script> -->
	<script>
		$(document).ready(function() {
    // Today's date setup
    var today = new Date();
    $('#weekday').html(today.toDateString().substring(0, 3));
    $('#date').html(today.getDate());
    var month = today.getMonth();
    var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
    $('#month').html(monthNames[month]);

    // Fetch geofence coordinates from the server
    $.ajax({
        type: "POST",
        url: "punch-in-out1.aspx/GetGeofenceLocation",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
		
        success: function(response) {
			console.log(response);
            // Set geofence with values from server
            const geofence = {
                latitude: response.d.Latitude,
                longitude: response.d.Longitude,
                radius: response.d.Radius
		
            };
			 // Set the employee ID label in JavaScript if needed
			 $('#lblEmpID').text(response.d.EmployeeID);
        
        // Proceed with geofence logic as needed
        console.log("Latitude:", geofence.latitude);
        console.log("Longitude:", geofence.longitude);
		console.log("Radius:", geofence.radius);

		

            // Check for location permission
            checkLocationPermission(geofence);
        },
        error: function(xhr, status, error) {
			console.error("Error fetching geofence location:", error);
    console.log("Status:", status);
    console.log("Response Text:", xhr.responseText);
        }
    });
});

// Haversine formula to calculate distance
function haversineDistance(coord1, coord2) {
			const R = 6371e3; // Earth radius in meters
			const lat1 = coord1.latitude * Math.PI / 180;
			const lat2 = coord2.latitude * Math.PI / 180;
			const deltaLat = (coord2.latitude - coord1.latitude) * Math.PI / 180;
			const deltaLong = (coord2.longitude - coord1.longitude) * Math.PI / 180;
	
			const a = Math.sin(deltaLat / 2) * Math.sin(deltaLat / 2) +
					  Math.cos(lat1) * Math.cos(lat2) *
					  Math.sin(deltaLong / 2) * Math.sin(deltaLong / 2);
			const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
	
			return R * c; // Distance in meters
		}
	

// Check if user location is within geofence
function checkGeofence(userLocation, geofence) {
    const distance = haversineDistance(userLocation, geofence);
	let status;
    if (distance <= geofence.radius) {
		status = "In";
        console.log("You are within the geofence!");
        alert("You are within the geofence!");
        document.getElementById("punchDetails").style.display = "block";
		document.getElementById("geofenceoutside").style.display = "none";
		//updategeofencestatustoDatabase();
    } 
	else {
		status = "Out";
        console.log("You are outside the geofence.");
        alert("You are outside the geofence.");
		console.log("Captured Location (Outside Geofence):", userLocation.latitude, userLocation.longitude);

		//saveLocationToDatabase(userLocation.latitude, userLocation.longitude);

        document.getElementById("punchDetails").style.display = "block";
		document.getElementById("geofenceoutside").style.display = "block";
		//document.getElementById("punchIndet").style.display = "none";

        document.getElementById("<%=hdnlat.ClientID %>").value = userLocation.latitude;
        document.getElementById("<%=hdnlong.ClientID %>").value = userLocation.longitude;
    }
	document.getElementById("<%= hdnGeofenceStatus.ClientID %>").value = status;

}

function saveLocationToDatabase(latitude, longitude) {
	var empId = document.getElementById("<%=hdnEmpId.ClientID %>").value;

    $.ajax({
        type: "POST",
        url: "punch-in-out1.aspx/SaveLocation", 
        data: JSON.stringify({ latitude: latitude, longitude: longitude, EmpID: empId }), // Include EmpID
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Location saved successfully:", response);
        },
        error: function (xhr, status, error) {
			console.error("Error saving geofence location:", error);
    console.log("Status:", status);
    console.log("Response Text:", xhr.responseText);
        }
    });
}

// function updategeofencestatustoDatabase() {
// 	var empId = document.getElementById("<%=hdnEmpId.ClientID %>").value;

//     $.ajax({
//         type: "POST",
//         url: "punch-in-out1.aspx/UpdatGeoStatus", 
//         data: JSON.stringify({ EmpID: empId }), // Include EmpID
//         contentType: "application/json; charset=utf-8",
//         dataType: "json",
//         success: function (response) {
//             console.log("Geo status saved successfully:", response);
//         },
//         error: function (xhr, status, error) {
// 			console.error("Error saving geofence status:", error);
//     console.log("Status:", status);
//     console.log("Response Text:", xhr.responseText);
//         }
//     });
// }

function checkLocationPermission(geofence) {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function(position) {
            success(position, geofence);
        }, error);
    } else {
        alert("Geolocation is not supported by this browser.");
    }
}

function success(position, geofence) {
    var lat = position.coords.latitude;
    var long = position.coords.longitude;


    document.getElementById("<%=lbllat.ClientID %>").innerHTML = lat;
    document.getElementById("<%=hdnlat.ClientID %>").value = lat;
    document.getElementById("<%=lbllong.ClientID %>").innerHTML = long;
    document.getElementById("<%=hdnlong.ClientID %>").value = long;

    const userLocation = { latitude: lat, longitude: long };
    checkGeofence(userLocation, geofence);

    var LatLng = new google.maps.LatLng(lat, long);
    var mapOptions = {
        center: LatLng,
        zoom: 12,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("MyMapLOC"), mapOptions);
    var marker = new google.maps.Marker({
        position: LatLng,
        map: map,
        title: "Your location"
    });

    document.getElementById("locationEnabledDiv").style.display = "block";
}

function error(err) {
    switch (err.code) {
        case err.PERMISSION_DENIED:
            $('#locationDeniedModal').modal('show');
            break;
        case err.POSITION_UNAVAILABLE:
            alert("Location information is unavailable.");
            break;
        case err.TIMEOUT:
            alert("The request to get user location timed out.");
            break;
        case err.UNKNOWN_ERROR:
            alert("An unknown error occurred.");
            break;
    }
}
	</script>
	<!-- <script>
		$(document).ready(function() {
			// Today's date setup
			var today = new Date();
			$('#weekday').html(today.toDateString().substring(0, 3));
			$('#date').html(today.getDate());
			var month = today.getMonth();
			var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
			$('#month').html(monthNames[month]);
	
			// Check for location permission
			checkLocationPermission();
		});
	
		// // Define your geofence
		// const geofence = {
		// 	latitude: 13.087807,
		// 	longitude: 90.180203,
		// 	radius: 100 // in meters
		// };

		// Fetch geofence coordinates from the server
		$.ajax({
        type: "POST",
        url: "punch-in-out1.aspx/GetGeofenceLocation",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(response) {
            // Set geofence with values from server
            const geofence = {
                latitude: response.d.Latitude,
                longitude: response.d.Longitude,
                radius: response.d.Radius
            };

            // Check for location permission
            checkLocationPermission(geofence);
        },
        error: function(xhr, status, error) {
            console.error("Error fetching geofence location:", error);
        }
    });

	
		// Haversine formula to calculate distance
		function haversineDistance(coord1, coord2) {
			const R = 6371e3; // Earth radius in meters
			const lat1 = coord1.latitude * Math.PI / 180;
			const lat2 = coord2.latitude * Math.PI / 180;
			const deltaLat = (coord2.latitude - coord1.latitude) * Math.PI / 180;
			const deltaLong = (coord2.longitude - coord1.longitude) * Math.PI / 180;
	
			const a = Math.sin(deltaLat / 2) * Math.sin(deltaLat / 2) +
					  Math.cos(lat1) * Math.cos(lat2) *
					  Math.sin(deltaLong / 2) * Math.sin(deltaLong / 2);
			const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
	
			return R * c; // Distance in meters
		}
	
		// Check if user location is within geofence
		function checkGeofence(userLocation) {
			const distance = haversineDistance(userLocation, geofence);
			if (distance <= geofence.radius) {
				console.log("You are within the geofence!");
				alert("You are within the geofence!"); // You can replace this with any notification method
				document.getElementById("punchDetails").style.display = "block"; // Show punch details

			} else {
				console.log("You are outside the geofence.");
				alert("You are outside the geofence.");
				document.getElementById("punchDetails").style.display = "none"; // Hide punch details
				 // Store location coordinates in hidden fields for server-side processing
				 document.getElementById("<%=hdnlat.ClientID %>").value = userLocation.latitude;
				 document.getElementById("<%=hdnlong.ClientID %>").value = userLocation.longitude;

			}
		}
	
		function checkLocationPermission() {
			if (navigator.geolocation) {
				navigator.geolocation.getCurrentPosition(success, error);
			} else {
				alert("Geolocation is not supported by this browser.");
			}
		}
	
		function success(position) {
			var lat = position.coords.latitude;
			var long = position.coords.longitude;
	
			// Update location labels
			document.getElementById("<%=lbllat.ClientID %>").innerHTML = lat;
			document.getElementById("<%=hdnlat.ClientID %>").value = lat;
			document.getElementById("<%=lbllong.ClientID %>").innerHTML = long;
			document.getElementById("<%=hdnlong.ClientID %>").value = long;
	
			// Check geofence
			const userLocation = { latitude: lat, longitude: long };
			checkGeofence(userLocation);
	
			// Initialize the map
			var LatLng = new google.maps.LatLng(lat, long);
			var mapOptions = {
				center: LatLng,
				zoom: 12,
				mapTypeId: google.maps.MapTypeId.ROADMAP
			};
			var map = new google.maps.Map(document.getElementById("MyMapLOC"), mapOptions);
			var marker = new google.maps.Marker({
				position: LatLng,
				map: map,
				title: "Your location"
			});

			// Send coordinates to the server using AJAX
			$.ajax({
        type: "POST",
        url: "punch-in-out1.aspx/UpdateLocation",
        data: JSON.stringify({ latitude: lat, longitude: long }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(response) {
            console.log("Location sent to server:", response.d);
        },
        error: function(xhr, status, error) {
            console.error("Error sending location:", error);
        }
    });
	
			// Show location enabled div
			document.getElementById("locationEnabledDiv").style.display = "block";
		}
	
		function error(err) {
			switch (err.code) {
				case err.PERMISSION_DENIED:
					$('#locationDeniedModal').modal('show'); // Show modal
					break;
				case err.POSITION_UNAVAILABLE:
					alert("Location information is unavailable.");
					break;
				case err.TIMEOUT:
					alert("The request to get user location timed out.");
					break;
				case err.UNKNOWN_ERROR:
					alert("An unknown error occurred.");
					break;
			}
		}
	</script> -->
	

	<!-- <script type="text/javascript">  

function checkLocationPermission() {
    // Check if geolocation is supported
    if (navigator.geolocation) {  
        // Attempt to get current position
        navigator.geolocation.getCurrentPosition(success, error);  
    } else {  
        alert("Geolocation is not supported by this browser.");  
    }  


		// Function to handle success in getting the current position
		function success(position) {  
			var lat = position.coords.latitude;  
			var long = position.coords.longitude;  
			var LatLng = new google.maps.LatLng(lat, long);  
			var mapOptions = {  
				center: LatLng,  
				zoom: 12,  
				mapTypeId: google.maps.MapTypeId.ROADMAP  
			};  
	
			var map = new google.maps.Map(document.getElementById("MyMapLOC"), mapOptions);  
			var marker = new google.maps.Marker({  
				position: LatLng,  
				title: "<div style='height:60px;width:200px'><b>Your location:</b><br />Latitude: " + lat + "<br />Longitude: " + long + "</div>"  
			});  
	
			document.getElementById("<%=lbllat.ClientID %>").innerHTML = lat;
			document.getElementById("<%=hdnlat.ClientID %>").value = document.getElementById("<%=lbllat.ClientID %>").innerHTML;
			document.getElementById("<%=lbllong.ClientID %>").innerHTML = long;
			document.getElementById("<%=hdnlong.ClientID %>").value = document.getElementById("<%=lbllong.ClientID %>").innerHTML;
			marker.setMap(map);  
			var getInfoWindow = new google.maps.InfoWindow({ 
				content: "<b>Your Current Location</b><br/> Latitude:" + lat + "<br /> Longitude:" + long + "" 
			});  
			getInfoWindow.open(map, marker);  

			// Show the div when location services are enabled
			var div = document.getElementById("locationEnabledDiv");
    if (div) {
        div.style.display = "block";
    }

		}  
	
		// Function to handle errors in getting the current position
		function error(err) {
			// Check error code to determine the reason for failure
			switch(err.code) {
				case err.PERMISSION_DENIED:
				$('#locationDeniedModal').modal('show'); // Show the Bootstrap modal

				// document.getElementById('locationDeniedMessage').style.display = 'block'; // Show the div
					break;
				case err.POSITION_UNAVAILABLE:
					alert("Location information is unavailable.");
					break;
				case err.TIMEOUT:
					alert("The request to get user location timed out.");
					break;
				case err.UNKNOWN_ERROR:
					alert("An unknown error occurred.");
					break;
			}
		}
	}
	
	 
	</script> -->

</asp:Content> 