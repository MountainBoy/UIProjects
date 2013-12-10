<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="WebUISite.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--<script src="Scripts/jquery-2.0.3.js"></script>
    <script src="Scripts/MagnificPopup.js"></script>--%>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="http://dimsemenov-static.s3.amazonaws.com/dist/jquery.magnific-popup.min.js"></script>
    <script src="http://s.codepen.io/assets/libs/empty.js"></script>
    <script type="text/ecmascript">
        // Inline popups
        $('#inline-popups').magnificPopup({
            delegate: 'a',
            removalDelay: 500, //delay removal by X to allow out-animation
            callbacks: {
                beforeOpen: function () {
                    this.st.mainClass = this.st.el.attr('data-effect');
                }
            },
            midClick: true // allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source.
        });


        // Image popups
        $('#image-popups').magnificPopup({
            delegate: 'a',
            type: 'image',
            removalDelay: 500, //delay removal by X to allow out-animation
            callbacks: {
                beforeOpen: function () {
                    // just a hack that adds mfp-anim class to markup 
                    this.st.image.markup = this.st.image.markup.replace('mfp-figure', 'mfp-figure mfp-with-anim');
                    this.st.mainClass = this.st.el.attr('data-effect');
                }
            },
            closeOnContentClick: true,
            midClick: true // allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source.
        });


        // Hinge effect popup
        $('a.hinge').magnificPopup({
            mainClass: 'mfp-with-fade',
            removalDelay: 1000, //delay removal by X to allow out-animation
            callbacks: {
                beforeClose: function () {
                    this.content.addClass('hinge');
                },
                close: function () {
                    this.content.removeClass('hinge');
                }
            },
            midClick: true
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h3>Magnific Popup CSS3-based animation effects</h3>
        <div class="links">
            <h4>Text-based:</h4>
            <ul id="inline-popups">
                <li><a href="#test-popup" data-effect="mfp-zoom-in">Zoom</a></li>
                <li><a href="#test-popup" data-effect="mfp-newspaper">Newspaper</a></li>
                <li><a href="#test-popup" data-effect="mfp-move-horizontal">Horizontal move</a></li>
                <li><a href="#test-popup" data-effect="mfp-move-from-top">Move from top</a></li>
                <li><a href="#test-popup" data-effect="mfp-3d-unfold">3d unfold</a></li>
                <li><a href="#test-popup" data-effect="mfp-zoom-out">Zoom-out</a></li>
            </ul>

            <a href="#test-popup" class="hinge">Popup with "hinge" close effect</a> (based on animate.css)
  
  
  <h4>Image-based:</h4>
            <ul id="image-popups">
                <li><a href="http://upload.wikimedia.org/wikipedia/commons/thumb/1/16/Prasat_Sikhoraphum_-_Sikhoraphum_edit1.jpg/800px-Prasat_Sikhoraphum_-_Sikhoraphum_edit1.jpg" data-effect="mfp-zoom-in">Zoom</a></li>
                <li><a href="http://upload.wikimedia.org/wikipedia/commons/thumb/1/16/Prasat_Sikhoraphum_-_Sikhoraphum_edit1.jpg/800px-Prasat_Sikhoraphum_-_Sikhoraphum_edit1.jpg" data-effect="mfp-newspaper">Newspaper</a></li>
                <li><a href="http://upload.wikimedia.org/wikipedia/commons/thumb/1/16/Prasat_Sikhoraphum_-_Sikhoraphum_edit1.jpg/800px-Prasat_Sikhoraphum_-_Sikhoraphum_edit1.jpg" data-effect="mfp-move-horizontal">Horizontal move</a></li>
                <li><a href="http://upload.wikimedia.org/wikipedia/commons/thumb/1/16/Prasat_Sikhoraphum_-_Sikhoraphum_edit1.jpg/800px-Prasat_Sikhoraphum_-_Sikhoraphum_edit1.jpg" data-effect="mfp-move-from-top">Move from top</a></li>
                <li><a href="http://upload.wikimedia.org/wikipedia/commons/thumb/1/16/Prasat_Sikhoraphum_-_Sikhoraphum_edit1.jpg/800px-Prasat_Sikhoraphum_-_Sikhoraphum_edit1.jpg" data-effect="mfp-3d-unfold">3d unfold</a></li>
                <li><a href="http://upload.wikimedia.org/wikipedia/commons/thumb/1/16/Prasat_Sikhoraphum_-_Sikhoraphum_edit1.jpg/800px-Prasat_Sikhoraphum_-_Sikhoraphum_edit1.jpg" data-effect="mfp-zoom-out">Zoom-out</a></li>
            </ul>
        </div>
        <div class="bottom-text">
            <p>CSS effects are inspired by <a href="http://tympanus.net/Development/ModalWindowEffects/">article on Codrops</a> by Mary Lou, <a href="http://lab.hakim.se/avgrund/">Avgrund</a> experiment by <a href="http://twitter.com/hakimel">Hakim El Hattab</a> and <a href="http://daneden.me/animate/">animate.css</a> by <a href="https://twitter.com/_dte">Dan Eden</a>.</p>
            <p>Magnific Popup on Github - <a href="https://github.com/dimsemenov/Magnific-Popup">https://github.com/dimsemenov/Magnific-Popup</a>,<br />
                plugin homepage - <a href="http://dimsemenov.com/plugins/magnific-popup/">http://dimsemenov.com/plugins/magnific-popup/</a></p>
        </div>

        <!-- Popup itself -->
        <div id="test-popup" class="white-popup mfp-with-anim mfp-hide">You may put any HTML here. This is dummy copy. It is not meant to be read. It has been placed here solely to demonstrate the look and feel of finished, typeset text. Only for show. He who searches for meaning here will be sorely disappointed.</div>


    </form>
</body>
</html>
