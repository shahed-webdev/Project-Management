﻿
//global model
const model = {
    FilePhoto: null,
    ProjectDonorIds: [],
    CityIds: [],
    ProjectBeneficiaries: [],

    ProjectReports: [],
    DeletedReports: [],
    AddedReports: []
};


//set image file
const inputPhoto = document.getElementById("inputPhoto");

//image file change
inputPhoto.addEventListener("change", function (e) {
    const imageError = document.getElementById("imageError");
    const pathInput = document.getElementById("filePath");
    const file = e.target.files[0];

    imageError.textContent = "";

    const size = file.size / 1024 / 1024;
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

    pathInput.value = file.name;

    //preview image
    readURL(e.target);

    //resize image
    const img = new Image();
    img.onload = function () {
        const width = 400;
        resizeImage(img, width, 0.5, file.name);
    }

    img.src = URL.createObjectURL(e.target.files[0]);
});

//resize photo
function resizeImage(img, width, step, fileName) {
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


    const dataUrl = canvas.toDataURL("image/png");
    const blobBin = atob(dataUrl.split(',')[1]);
    const array = [];

    for (let i = 0; i < blobBin.length; i++) {
        array.push(blobBin.charCodeAt(i));
    }

    const file = new Blob([new Uint8Array(array)], { type: 'image/png' });
    file.name = fileName;

    model.FilePhoto = file;
}

//preview image
function readURL(input) {
    if (input.files && input.files[0]) {
        const imgFilePhoto = document.getElementById("imgFilePhoto");
        const reader = new FileReader();

        reader.onload = function (e) {
            imgFilePhoto.src = e.target.result;
        };

        reader.readAsDataURL(input.files[0]);
    }
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
        $.notify("Report Already Added!", "error");
        return;
    };

    const reports = {
        ReportTypeId: id,
        Attachment: e.target.files[0],
        FileTitle: e.target.files[0].name
    }

    model.ProjectReports.push(reports);

    //new added report
    model.AddedReports.push(reports);

    const li = document.createElement("li");
    li.className = "list-group-item d-flex justify-content-between align-items-center";
    li.innerHTML = `
            <div class="report-tems">
              <span>${text}</span>
              <i>${e.target.files[0].name}</i>
            </div>
            <i data-id="${id}" data-old="false" class="remove fas fa-trash-alt red-text"></i>`;
    reportList.appendChild(li);

    this.value = "";

    $.notify("Report Successfully Added", "success");
});

//remove
reportList.addEventListener("click", function (evt) {
    const element = evt.target;
    const onDelete = element.classList.contains("remove");

    if (!onDelete) return;

    const id = +element.getAttribute("data-id");
    const isOldData = element.getAttribute("data-old");
    const fileName = element.getAttribute("data-filename");

    if (isOldData === "true") {
        const oldData = { FileName: fileName, ReportTypeId: id }
        model.DeletedReports.push(oldData);
    }

    model.ProjectReports = model.ProjectReports.filter(el => el.ReportTypeId !== id);

    //remove newly added report
    model.AddedReports = model.AddedReports.filter(el => el.ReportTypeId !== id);

    element.parentElement.remove();
});


//selectors
const formStep1 = document.getElementById("formStep1");
const formStep2 = document.getElementById("formStep2");
const btnNext = document.getElementById("btnNext");
const btnPrevious = document.getElementById("btnPrevious");

//location
const selectCountry = document.getElementById("selectCountry");
const selectState = document.getElementById("selectState");
const selectCity = document.getElementById("selectCity");

//create dropdown options
function createDropdownOption(item, disabled, selected) {
    const option = document.createElement("option");
    option.value = item.value;
    option.text = item.label;
    option.disabled = disabled;
    option.selected = selected;

    return option;
}


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
            fragment.appendChild(createDropdownOption({ value: "", label: "Sub-District" }, true, true));

            response.Data.forEach(item => {
                fragment.appendChild(createDropdownOption(item, false, false));
            });

            selectCity.innerHTML = "";
            selectCity.appendChild(createDropdownOption({ value: "", label: "Village" }, true, true));

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
            fragment.appendChild(createDropdownOption({ value: "", label: "Village" }, true, true));

            response.Data.forEach(item => {
                fragment.appendChild(createDropdownOption(item, false, false));
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
        return `${item.Name}, ${item.Email}`;
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
        return item;
    }
});

//**add donor**
function appendDonor(donor) {
    if (model.ProjectDonorIds.indexOf(donor.DonorId) !== -1) return;

    model.ProjectDonorIds.push(donor.DonorId);

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
    const index = model.ProjectDonorIds.indexOf(id);

    if (index > -1) {
        model.ProjectDonorIds.splice(index, 1);
        element.parentElement.remove();
    }
});


/***Location****/
const btnLocationAdd = document.getElementById("btnLocationAdd");
const bodyLocation = document.getElementById("bodyLocation");

btnLocationAdd.addEventListener("click", function () {
    const cityId = +selectCity.value;
    if (!cityId) return;

    if (model.CityIds.indexOf(cityId) !== -1) return;

    model.CityIds.push(cityId);

    const tr = document.createElement("tr");
    tr.innerHTML = `
            <td>${getSelectedText(selectCountry)}</td>
            <td>${getSelectedText(selectState)}</td>
            <td>${getSelectedText(selectCity)}</td>
            <td><i data-id="${cityId}" class="remove fas fa-trash-alt"></i></td>`;

    bodyLocation.appendChild(tr);
});

//get dropdown selected text
function getSelectedText(select) {
    return select.options[select.selectedIndex].text;
}

//remove location
bodyLocation.addEventListener("click", function (evt) {
    const element = evt.target;
    const onDelete = element.classList.contains("remove");

    if (!onDelete) return;

    const id = +element.getAttribute("data-id");

    model.CityIds = model.CityIds.filter(el => el !== id);
    element.parentElement.parentElement.remove();
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
    tr.innerHTML = `<td>${type}</td><td>${count}</td><td><i data-id="${id}" class="remove fas fa-trash-alt"></i></td>`;
    beneficiaryTypeBody.appendChild(tr);

    inputBeneficiaryCount.value = "";
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


//posted data
function postProjectData(sef, btn) {
    const formData = new FormData();
    formData.append('ProjectId', document.getElementById("hiddenProjectId").value);
    formData.append('ProjectSectorId', formStep1.hiddenProjectSectorId.value);
    formData.append('ProjectStatusId', formStep1.selectStatus.value);
    formData.append('Title', formStep1.inputTitle.value);
    formData.append('Description', formStep1.inputDescription.value);
    formData.append('Keyword', formStep1.inputKeyword.value);
    formData.append('DonorType', formStep1.inputDonorType.value);

    formData.append('TotalBudgetBdt', formStep1.inputTotalBudgetBdt.value);
    formData.append('TotalBudgetUsd', formStep1.inputTotalBudgetUsd.value);
    formData.append('TotalExpenditure', formStep1.inputTotalExpenditure.value);

    formData.append('DirectIndirectType', formStep1.selectDirectIndirectType.value);
    formData.append('IndividualHouseholdType', formStep1.selectIndividualHouseholdType.value);
    formData.append('Count', formStep1.inputCount.value);
    formData.append('TotalCount', formStep1.inputTotalCount.value);

    if (model.FilePhoto)
        formData.append('FilePhoto', model.FilePhoto, model.FilePhoto.name);

    formData.append('StartDate', formStep1.inputStartDate.value);
    formData.append('EndDate', formStep1.inputEndDate.value);

    model.ProjectDonorIds.forEach((item, i) => {
        formData.append(`ProjectDonorIds[${i}]`, item);
    });

    model.CityIds.forEach((item, i) => {
        formData.append(`CityIds[${i}]`, item);
    });

    model.ProjectBeneficiaries.forEach((item, i) => {
        formData.append(`ProjectBeneficiaries[${i}].ProjectBeneficiaryTypeId`, item.ProjectBeneficiaryTypeId);
        formData.append(`ProjectBeneficiaries[${i}].Count`, item.Count);
    });

    //2nd step
    formData.append('SubmissionDate', formStep2.inputSubmissionDate.value);

    //added
    model.AddedReports.forEach((item, i) => {
        formData.append(`AddedReports[${i}].ReportTypeId`, item.ReportTypeId);
        formData.append(`AddedReports[${i}].Attachment`, item.Attachment, item.Attachment.name);
        formData.append(`AddedReports[${i}].FileTitle`, item.FileTitle);
    });

    //deleted
    model.DeletedReports.forEach((item, i) => {
        formData.append(`DeletedReports[${i}].ReportTypeId`, item.ReportTypeId);
        formData.append(`DeletedReports[${i}].FileName`, item.FileName);
    });

    disableButton(btn, true);

    $.ajax({
        url: "/Projects/PostUpdateProject",
        type: "POST",
        data: formData,
        processData: false,
        contentType: false,
        success: response => {
            disableButton(btn, false);
            $.notify(response.Message, response.IsSuccess ? "success" : "error");
        },
        error: err => {
            console.log(err);
            disableButton(btn, false);
        }
    });
}

//post step 1
formStep1.addEventListener("submit", function (evt) {
    evt.preventDefault();
    postProjectData(this, this.btnSubmit1);
});

//submit second step
formStep2.addEventListener("submit", function (evt) {
    evt.preventDefault();

    if (!formStep1.inputTitle.value) {
        stepChange(false);
        formStep1.inputTitle.focus();
        return;
    }

    postProjectData(this, this.btnSubmit2);
});

//enable/disable btn
function disableButton(btn, isDisable) {
    btn.disabled = isDisable;
    btn.textContent = isDisable ? "submitting.." : "Submit";
}

//next click
btnNext.addEventListener("click", function (evt) {
    evt.preventDefault();

    stepChange(true);

    if (formStep1.inputTitle.value) {
        formStep2.inputProjectName.value = formStep1.inputTitle.value;
        formStep2.inputProjectName.nextElementSibling.classList.add("active");
    }
});

//next or prev page
function stepChange(isNext) {
    if (isNext) {
        formStep1.style.display = "none";
        formStep2.style.display = "block";
    } else {
        formStep1.style.display = "block";
        formStep2.style.display = "none";
    }
}

//Previous
btnPrevious.addEventListener("click", function (evt) {
    evt.preventDefault();

    stepChange(false);
});
