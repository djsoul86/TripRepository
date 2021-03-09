let listViajeros = [];
let listViajes = [];
let listReservas = [];
let currentId = 0;
let currentViajeId = 0;
$(document).ready(function () {
    // Seccion Viajeros
    getViajerosList();
    getPaisList();
    getViajesList();
    getReservasList();
    viajeroEvent(['containerViajes', 'containerReservas'], 'containerViajero', 'liViajero', ['liViaje', 'liReservar']);
    $("#formViajero").on("submit", function (event) {
        const viajero = {
            cedula: $('#cedula').val(),
            nombre: $('#nombre').val(),
            direccion: $('#direccion').val(),
            telefono: $('#telefono').val()
        }
        event.preventDefault();
        if (currentId !== 0) {
            update(viajero);
        } else {
            fetch('http://localhost:2393/api/Viajero/Create', {
                method: "POST",
                body: JSON.stringify(viajero),
                headers: { "Content-type": "application/json; charset=UTF-8" }
            }).then(response => response.json())
                .then(json => {
                    const markup = `<tr id="${json.id}_row"><td>${viajero.cedula}</td><td>${viajero.nombre}</td><td>${viajero.direccion}</td><td>${viajero.telefono}</td><td><button class="btn btn-danger"><span id="${json.id}" onclick="eliminar(this.id)">Eliminar</span></button></td><td><span class="btn btn-secondary" id="${viajero.id}" onclick="editar(this.id)">Editar</span></td><tr>`;
                    $("#tblViajeros tbody").append(markup);
                    $('#formViajero').trigger("reset");
                }).catch(err => console.log(err));
        }
    });

    function update(viajero) {
        fetch(`http://localhost:2393/api/Viajero/Update?id=${currentId}`, {
            method: "PUT",
            body: JSON.stringify(viajero),
            headers: { "Content-type": "application/json; charset=UTF-8" }
        }).then(response => response.json())
            .then(json => {
                $('#formViajero').trigger("reset");
                currentId = 0;
                listViajeros.forEach(data => {
                    document.getElementById(`${data.id}_row`).remove();
                });
                getViajerosList();
            }).catch(err => console.log(err));
    }

    // Seccion Viajes
    $("#formViajes").on("submit", function (event) {
        if (!$("#origen option:selected").val().includes("Seleccione") && !$("#destino option:selected").val().includes("Seleccione")) {
            const viaje = {
                codigoViaje: $('#codigo').val(),
                numeroPlazas: +$('#plazas').val(),
                origenId: +$("#origen option:selected").val(),
                destinoId: +$("#destino option:selected").val(),
                precio: +$('#precio').val()
            }
            event.preventDefault();
            if (currentViajeId !== 0) {
                updateViaje(viaje);
            } else {
                fetch('http://localhost:2393/api/Viajes/Create', {
                    method: "POST",
                    body: JSON.stringify(viaje),
                    headers: { "Content-type": "application/json; charset=UTF-8" }
                }).then(response => response.json())
                    .then(json => {
                        const markup = `<tr id="${json.id}_rowViaje"><td>${json.codigoViaje}</td><td>${json.numeroPlazas}</td><td>${json.origen.nombre}</td><td>${json.destino.nombre}</td><td>${json.precio}</td><td><button class="btn btn-danger"><span id="${json.id}" onclick="eliminarViaje(this.id)">Eliminar</span></button></td><td><span class="btn btn-secondary" id="${viaje.id}" onclick="editarViaje(this.id)">Editar</span></td><tr>`;
                        $("#tblViajes tbody").append(markup);
                        $('#formViajes').trigger("reset");
                    }).catch(err => console.log(err));
            }
        } else {
            alert("Debe seleccionar origen y destino");
        }
    });

    function updateViaje(viaje) {
        fetch(`http://localhost:2393/api/Viajes/Update?id=${currentViajeId}`, {
            method: "PUT",
            body: JSON.stringify(viaje),
            headers: { "Content-type": "application/json; charset=UTF-8" }
        }).then(response => response.json())
            .then(json => {
                $('#formViajes').trigger("reset");
                currentId = 0;
                listViajes.forEach(data => {
                    document.getElementById(`${data.id}_rowViaje`).remove();
                });
                getViajesList();
            }).catch(err => console.log(err));
    }

    // Reservas
    $("#formReservas").on("submit", function (event) {
        if (!$("#viajeroOption option:selected").val().includes("Seleccione") && !$("#viajeOption option:selected").val().includes("Seleccione")) {
            const reserva = {
                idViajero: +$("#viajeroOption option:selected").val(),
                idViaje: +$("#viajeOption option:selected").val(),
            }
            event.preventDefault();
            if (currentViajeId !== 0) {
                updateViaje(reserva);
            } else {
                fetch('http://localhost:2393/api/Reserva/Create', {
                    method: "POST",
                    body: JSON.stringify(reserva),
                    headers: { "Content-type": "application/json; charset=UTF-8" }
                }).then(response => response.json())
                    .then(json => {
                        const markup = `<tr id="${json.id}_rowReserva"><td>${json.viajero.nombre}</td><td>${json.viaje.fullName}</td><td><button class='btn btn-danger'><span id="${json.id}" onclick="eliminarReserva(this.id)">Eliminar</span></button></td></tr>`;
                        $("#tblReservas tbody").append(markup);
                        $('#formReservas').trigger("reset");
                    }).catch(err => console.log(err));
            }
        } else {
            alert("Debe seleccionar usuario y destino");
        }
    });
});

function getViajerosList() {
    fetch(`http://localhost:2393/api/Viajero/GetViajerosList`, {
        method: "GET",
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(response => response.json())
        .then(json => {
            listViajeros = json;
            json.forEach(viajero => {
                if (viajero.cedula !== null) {
                    const markup = `<tr id="${viajero.id}_row"><td>${viajero.cedula}</td><td>${viajero.nombre}</td><td>${viajero.direccion}</td><td>${viajero.telefono}</td><td><span class="btn btn-danger" id="${viajero.id}" onclick="eliminar(this.id)">Eliminar</span></td><td><span class="btn btn-secondary" id="${viajero.id}" onclick="editar(this.id)">Editar</span></td><tr>`;
                    $("#tblViajeros tbody").append(markup);
                    var viajeroOption = new Option(viajero.nombre, viajero.id);
                    $("#viajeroOption").append(viajeroOption);
                }
            });
        }).catch(err => console.log(err));
}

function getViajesList() {
    fetch(`http://localhost:2393/api/Viajes/GetViajesList`, {
        method: "GET",
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(response => response.json())
        .then(json => {
            listViajes = json;
            json.forEach(viaje => {
                if (viaje.origen !== null) {
                    const markup = `<tr id="${viaje.id}_rowViaje"><td>${viaje.codigoViaje}</td><td>${viaje.numeroPlazas}</td><td>${viaje.origen.nombre}</td><td>${viaje.destino.nombre}</td><td>${viaje.precio}</td><td><button class="btn btn-danger"><span id="${viaje.id}" onclick="eliminarViaje(this.id)">Eliminar</span></button></td><td><span class="btn btn-secondary" id="${viaje.id}" onclick="editarViaje(this.id)">Editar</span></td><tr>`;
                    $("#tblViajes tbody").append(markup);
                    var viajeOption = new Option(viaje.fullName, viaje.id);
                    $("#viajeOption").append(viajeOption);
                }
            });
        }).catch(err => console.log(err));
}

function getPaisList() {
    fetch(`http://localhost:2393/api/Paises/GetPaisesList`, {
        method: "GET",
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(response => response.json())
        .then(json => {
            json.forEach(pais => {
                var origen = new Option(pais.nombre, pais.id);
                var destino = new Option(pais.nombre, pais.id);
                $("#origen").append(origen);
                $("#destino").append(destino);
            });
        }).catch(err => console.log(err));
}

function getReservasList() {
    fetch(`http://localhost:2393/api/Reserva/GetReservasList`, {
        method: "GET",
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(response => response.json())
        .then(json => {
            listViajes = json;
            json.forEach(viaje => {
                if (viaje.origen !== null) {
                    const markup = `<tr id="${viaje.id}_rowReserva"><td>${viaje.viajero.nombre}</td><td>${viaje.viaje.fullName}</td><td><button class='btn btn-danger'><span id="${viaje.id}" onclick="eliminarReserva(this.id)">Eliminar</span></button></td></tr>`;
                    $("#tblReservas tbody").append(markup);
                }
            });
        }).catch(err => console.log(err));
}

function eliminar(id) {
    fetch(`http://localhost:2393/api/Viajero/${id}`, {
        method: "DELETE",
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(response => response.json())
        .then(json => {
            document.getElementById(`${id}_row`).remove();
            listViajeros = listViajeros.filter(x => x.id !== +id);
        }).catch(err => console.log(err));
}

function eliminarViaje(id) {
    fetch(`http://localhost:2393/api/Viajes/${id}`, {
        method: "DELETE",
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(response => response.json())
        .then(json => {
            document.getElementById(`${id}_rowViaje`).remove();
            listViajeros = listViajeros.filter(x => x.id !== +id);
        }).catch(err => console.log(err));
}

function eliminarReserva(id) {
    fetch(`http://localhost:2393/api/Reserva/${id}`, {
        method: "DELETE",
        headers: { "Content-type": "application/json; charset=UTF-8" }
    }).then(response => response.json())
        .then(json => {
            document.getElementById(`${id}_rowReserva`).remove();
            listReservas = listReservas.filter(x => x.id !== +id);
        }).catch(err => console.log(err));
}

function viajeroEvent(elementsToHide, elementToShow, itemToActive, itemsToDeactivate) {
    const sectionViajero = document.getElementById(elementToShow);
    sectionViajero.style.display = 'block';
    const elementToActivate = document.getElementById(itemToActive);
    elementToActivate.classList.add('active');

    elementsToHide.forEach(element => {
        const sectionViajes = document.getElementById(element);
        sectionViajes.style.display = 'none';
    });
    itemsToDeactivate.forEach(item => {
        const elementToDeactivate = document.getElementById(item);
        elementToDeactivate.classList.remove('active');
    });
}

function editar(id) {
    $('#cedula').val(listViajeros.find(x => x.id === +id).cedula);
    $('#nombre').val(listViajeros.find(x => x.id === +id).nombre);
    $('#direccion').val(listViajeros.find(x => x.id === +id).direccion);
    $('#telefono').val(listViajeros.find(x => x.id === +id).telefono);
    currentId = id;
}

function editarViaje(id) {
    $('#codigo').val(listViajes.find(x => x.id === +id).codigoViaje);
    $('#plazas').val(listViajes.find(x => x.id === +id).numeroPlazas);
    $('#origen').val(listViajes.find(x => x.id === +id).origen.id);
    $('#destino').val(listViajes.find(x => x.id === +id).destino.id);
    $('#precio').val(listViajes.find(x => x.id === +id).precio);
    currentViajeId = id;
}