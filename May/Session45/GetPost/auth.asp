<h1>Classic ASP page</h1>
<body>
    Welcome
    <%
        response.write(request.form("Username"))
        response.write(request.form("userPassword")) 
    %>
</body>