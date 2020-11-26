
//global model
const model = {
    ProjectDonors: [],
    ProjectBeneficiaries: [],
    ProjectReports: []
};


//set image file
const inputPhoto = document.getElementById("inputPhoto");

//image file
inputPhoto.addEventListener("change", function (e) {
    const imageError = document.getElementById("imageError");
    const pathInput = document.getElementById("filePath");

    imageError.textContent = "";

    const size = e.target.files[0].size / 1024 / 1024;
    const allowSize = 2;
    const regex = new RegExp("(.*?)\.(jpeg|jpg|png|webp)$");

    if (!(regex.test(e.target.value.toLowerCase()))) {
        e.target.value = "";
        pathInput.value = "";

        imageError.textContent = `Please select correct file format`;
        return;
    }

    if (size > allowSize) {
        e.target.value = "";
        pathInput.value = "";

        imageError.textContent = `image size must be less than ${allowSize}MB. your file size:${size.toFixed()} MB`;
        return;
    }

    pathInput.value = e.target.files[0].name;

    //resize image
    const img = new Image();
    img.onload = function () {
        const width = 200;
        resizeImage(img, width, 0.5);
    }

    img.src = URL.createObjectURL(e.target.files[0]);
});

//resize photo
function resizeImage(img, width, step) {
    const canvas = document.createElement('canvas');
    const ctx = canvas.getContext("2d");
    const oc = document.createElement('canvas');
    const ctx2d = oc.getContext('2d');

    canvas.width = width;
    canvas.height = canvas.width * img.height / img.width;

    if (img.width * step > width) {
        const mul = 1 / step;
        let cur = {
            width: Math.floor(img.width * step),
            height: Math.floor(img.height * step)
        };

        oc.width = cur.width;
        oc.height = cur.height;

        ctx2d.drawImage(img, 0, 0, cur.width, cur.height);

        while (cur.width * step > width) {
            cur = {
                width: Math.floor(cur.width * step),
                height: Math.floor(cur.height * step)
            };
            ctx2d.drawImage(oc, 0, 0, cur.width * mul, cur.height * mul, 0, 0, cur.width, cur.height);
        }

        ctx.drawImage(oc, 0, 0, cur.width, cur.height, 0, 0, canvas.width, canvas.height);
    } else {
        ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
    }

    // document.getElementById("stepped").src = canvas.toDataURL();

    const dataUrl = canvas.toDataURL("image/png");
    const blobBin = atob(dataUrl.split(',')[1]);
    const array = [];

    for (let i = 0; i < blobBin.length; i++) {
        array.push(blobBin.charCodeAt(i));
    }

    const file = new Blob([new Uint8Array(array)], { type: 'image/png' });
    model.Photo = file;

    //const formData = new FormData();
    //formData.append("photo", file);

    //$.ajax({
    //    url: "uploadFile.php",
    //    type: "POST",
    //    data: formData,
    //    processData: false,
    //    contentType: false
    //})
}


//file attachment
const inputAttachment = document.getElementById("inputAttachment");
const selectReportName = document.getElementById("selectReportName");
const errorReportName = document.getElementById("errorReportName");
const reportList = document.getElementById("report-list");

//add
inputAttachment.addEventListener("change", function (e) {
    errorReportName.textContent = "";
    const id = +selectReportName.value;
    const text = selectReportName.options[selectReportName.selectedIndex].text;

    if (!id) {
        errorReportName.textContent = "Select Report Name";
        return;
    }

    const isAdded = model.ProjectReports.some(function (el) {
        return el.ReportTypeId === id;
    });

    if (isAdded) {
        this.value = "";
        return;
    };

    const pathInput = document.getElementById("filePath2");
    pathInput.value = e.target.files[0].name;

    const reports = {
        ReportTypeId: id,
        Attachment: e.target.files[0]
    }

    model.ProjectReports.push(reports);

    const li = document.createElement("li");
    li.className = "list-group-item d-flex justify-content-between align-items-center";
    li.innerHTML = `<span>${text}</span><i data-id="${id}" class="remove fas fa-trash-alt red-text"></i>`;
    reportList.appendChild(li);

    this.value = "";
    pathInput.value = "";
});

//remove
reportList.addEventListener("click", function(evt) {
    const element = evt.target;


});


//selectors
const formStep = document.getElementById("formStep");
const btnPrevious = document.getElementById("btnPrevious");
const formAdd = document.getElementById("formAdd");
//location
const selectCountry = document.getElementById("selectCountry");
const selectState = document.getElementById("selectState");
const selectCity = document.getElementById("selectCity");

//on change country
selectCountry.addEventListener("change", function () {
    const id = +this.value

    if (!id) return;

    $.ajax({
        url: "/Projects/GetStateByCountry",
        data: { id },
        success: function (response) {
            if (!response.IsSuccess) return;

            const fragment = document.createDocumentFragment();
            const option1 = document.createElement("option");
            option1.value = "";
            option1.text = "State";
            option1.setAttribute("disabled", "disabled");
            option1.setAttribute("selected", true);
            fragment.appendChild(option1);

            response.Data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.value;
                option.text = item.label;
                fragment.appendChild(option);
            });

            selectState.innerHTML = "";
            selectState.appendChild(fragment);
        },
        error: function (err) {
            console.log(err);
        }
    });
});

//on change state
selectState.addEventListener("change", function () {
    const id = +this.value

    if (!id) return;

    $.ajax({
        url: "/Projects/GetCityByState",
        data: { id },
        success: function (response) {
            if (!response.IsSuccess) return;

            const fragment = document.createDocumentFragment();
            const option1 = document.createElement("option");
            option1.value = "";
            option1.text = "City";
            option1.setAttribute("disabled", "disabled");
            option1.setAttribute("selected", true);
            fragment.appendChild(option1);

            response.Data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.value;
                option.text = item.label;
                fragment.appendChild(option);
            });

            selectCity.innerHTML = "";
            selectCity.appendChild(fragment);
        },
        error: function (err) {
            console.log(err);
        }
    });
});

//Donors autocomplete
const donorContainer = document.getElementById("donor-container");
$('#inputDonors').typeahead({
    minLength: 1,
    displayText: function (item) {
        return item.Name;
    },
    afterSelect: function (item) {
        this.$element[0].value = "";
    },
    source: function (request, result) {
        $.ajax({
            url: "/Projects/FindDonors",
            data: { name: request },
            success: function (response) { result(response); },
            error: function (err) { console.log(err) }
        });
    },
    updater: function (item) {
        appendDonor(item);
        console.log(item)
        return item;
    }
});

//**add donor**
function appendDonor(donor) {
    if (model.ProjectDonors.indexOf(donor.DonorId) !== -1) return;

    model.ProjectDonors.push(donor.DonorId);

    const span = document.createElement("span");
    span.innerHTML = `<strong>${donor.Name}</strong><i data-id="${donor.DonorId}" class="delete fas fa-times-circle"></i>`;

    donorContainer.appendChild(span);
}

//remove donor
donorContainer.addEventListener("click", function (evt) {
    const element = evt.target;
    const onDelete = element.classList.contains("delete");

    if (!onDelete) return;

    const id = +element.getAttribute("data-id");
    const index = model.ProjectDonors.indexOf(id);

    if (index > -1) {
        model.ProjectDonors.splice(index, 1);
        element.parentElement.remove();
    }
});


//**Beneficiary Add***
const btnBeneficiaryAdd = document.getElementById("btnBeneficiaryAdd");
const beneficiaryError = document.getElementById("beneficiaryError");
const selectBeneficiaryType = document.getElementById("selectBeneficiaryType");
const inputBeneficiaryCount = document.getElementById("inputBeneficiaryCount");
const beneficiaryTypeBody = document.getElementById("beneficiaryTypeBody");

//add
btnBeneficiaryAdd.addEventListener("click", function (evt) {
    evt.preventDefault();
    beneficiaryError.textContent = "";

    const id = +selectBeneficiaryType.value;
    const type = selectBeneficiaryType.options[selectBeneficiaryType.selectedIndex].text;
    const count = +inputBeneficiaryCount.value;

    if (!id) {
        beneficiaryError.textContent = "Select Beneficiary Type";
        return;
    }

    if (!count) {
        beneficiaryError.textContent = "Add Beneficiary Count";
        return;
    }

    const obj = {
        ProjectBeneficiaryTypeId: id,
        Count: count
    }

    const isAdded = model.ProjectBeneficiaries.some(function (el) {
        return el.ProjectBeneficiaryTypeId === id;
    });

    if (isAdded) return;

    model.ProjectBeneficiaries.push(obj);

    const tr = document.createElement("tr");
    tr.innerHTML = `<td>${type}</td><td>${count}</td><td><i data-id="${id}" class="remove fas fa-trash-alt red-text" style="cursor: pointer"></i></td>`;
    beneficiaryTypeBody.appendChild(tr);
});

//remove
beneficiaryTypeBody.addEventListener("click", function (evt) {
    const element = evt.target;
    const onDelete = element.classList.contains("remove");

    if (!onDelete) return;

    const id = +element.getAttribute("data-id");

    model.ProjectBeneficiaries = model.ProjectBeneficiaries.filter(el => el.ProjectBeneficiaryTypeId !== id);
    element.parentElement.parentElement.remove();
});


//first step
formStep.addEventListener("submit", function (evt) {
    evt.preventDefault();

    stepChange(true);

    if (this.inputTitle.value) {
        formAdd.inputProjectName.value = this.inputTitle.value;
        formAdd.inputProjectName.nextElementSibling.classList.add("active");

        formAdd.inputReportName.value = this.inputTitle.value;
        formAdd.inputReportName.nextElementSibling.classList.add("active");
    }
});

//Previous
btnPrevious.addEventListener("click", function (evt) {
    evt.preventDefault();

    stepChange(false);
});

//post project
formAdd.addEventListener("submit", function (evt) {
    evt.preventDefault();

    if (!formStep.inputTitle.value) {
        stepChange(false);

        formStep.inputTitle.setAttribute("required", "required");
        formStep.inputTitle.focus();

        return;
    }


    document.getElementById("successMessage").style.display = "block";
    this.style.display = "none";
})

//next or prev page
function stepChange(isNext) {
    if (isNext) {
        formStep.style.display = "none";
        formAdd.style.display = "block";
    } else {
        formStep.style.display = "block";
        formAdd.style.display = "none";
    }
}

