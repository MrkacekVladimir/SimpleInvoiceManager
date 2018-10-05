// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let invoiceItemId = 0;
let nameInput = document.getElementById('newInvoiceItemName');
let quantityInput = document.getElementById('newInvoiceItemQuantity');
let perUnitInput = document.getElementById('newInvoiceItemPrice'); 
let priceSpan = document.getElementById('newInvoiceItemTotalPrice'); 

document.getElementById('btnAddNewItem').addEventListener('click', handleNewInvoiceItem);
function handleNewInvoiceItem(event)
{    
    if (isEmptyOrSpaces(nameInput.value) || isEmptyOrSpaces(quantityInput.value) || isEmptyOrSpaces(perUnitInput.value) || perUnitInput.value == 0 || quantityInput.value == 0)
        return;

    let trElement = document.createElement('tr');    

    let indexTdElement = document.createElement('td');
    indexTdElement.style.display = 'none';
    let indexInputElement = document.createElement('input');
    indexInputElement.name = 'Items.Index';
    indexInputElement.type = 'hidden';
    indexInputElement.value = invoiceItemId;
    indexInputElement.readOnly = true;
    indexInputElement.classList.add('form-control');
    indexTdElement.appendChild(indexInputElement);
    // "<td style='display:none'><input name='Items.Index' type='hidden' value='" + invoiceItemId + "' /> </td>";

    let nameElement = document.createElement('td');  
    newNameInputElement = document.createElement('input');
    newNameInputElement.value = nameInput.value;
    newNameInputElement.name = 'Items[' + invoiceItemId + '].Name';
    newNameInputElement.readOnly = true;
    newNameInputElement.classList.add('form-control');
    nameElement.appendChild(newNameInputElement);

    let quantityElement = document.createElement('td');    
    newQuantityInputElement = document.createElement('input');
    newQuantityInputElement.name = 'Items[' + invoiceItemId + '].Quantity';
    newQuantityInputElement.value = quantityInput.value;    
    newQuantityInputElement.readOnly = true;
    newQuantityInputElement.classList.add('form-control');
    quantityElement.appendChild(newQuantityInputElement);

    let perUnitElement = document.createElement('td');    
    newPerUnitInputElement = document.createElement('input');    
    newPerUnitInputElement.value = perUnitInput.value;
    newPerUnitInputElement.name = 'Items[' + invoiceItemId + '].PricePerUnit';
    newPerUnitInputElement.readOnly = true;
    newPerUnitInputElement.classList.add('form-control');
    perUnitElement.appendChild(newPerUnitInputElement);

    let totalPrizeElement = document.createElement('td');       
    newTotalPrizeInputElement = document.createElement('input');    
    newTotalPrizeInputElement.value = (parseFloat(quantityInput.value) * parseFloat(perUnitInput.value)).toString();
    newTotalPrizeInputElement.name = 'Items[' + invoiceItemId + '].Total';
    newTotalPrizeInputElement.readOnly = true;
    newTotalPrizeInputElement.classList.add('form-control');
    totalPrizeElement.appendChild(newTotalPrizeInputElement);

    let deleteElement = document.createElement('td');    
    let deleteBtn = document.createElement('a');
    deleteBtn.classList.add('btn');
    deleteBtn.classList.add('btn-danger');
    deleteBtn.classList.add('text-white');
    deleteBtn.innerText = 'X';
    deleteBtn.addEventListener('click', function () {
        trElement.remove();
        invoiceItemId--;
    });
    deleteElement.appendChild(deleteBtn);

    trElement.appendChild(indexTdElement);
    trElement.appendChild(nameElement);
    trElement.appendChild(quantityElement);
    trElement.appendChild(perUnitElement);
    trElement.appendChild(totalPrizeElement);
    trElement.appendChild(deleteElement);
    trElement.id = invoiceItemId++;

    let body = document.getElementById('invoiceItemsBody');    
    body.insertBefore(trElement, body.childNodes[0]);
    clearInvoiceItemInputs();
}

function clearInvoiceItemInputs() {
    nameInput.value = "";
    quantityInput.value = null;
    perUnitInput.value = null;
    priceSpan.innerText = 0;
}

document.getElementById('newInvoiceItemQuantity').addEventListener('change', handlePriceChange);
document.getElementById('newInvoiceItemQuantity').addEventListener('keyup', handlePriceChange);
document.getElementById('newInvoiceItemPrice').addEventListener('change', handlePriceChange);
document.getElementById('newInvoiceItemPrice').addEventListener('keyup', handlePriceChange);
function handlePriceChange(event)
{     
    let quantityInputValue = document.getElementById('newInvoiceItemQuantity').value;
    let priceInputValue = document.getElementById('newInvoiceItemPrice').value;
    let totalPrice = parseFloat(quantityInputValue) * parseFloat(priceInputValue);    
    priceSpan.innerText = isNaN(totalPrice) ? 0 : totalPrice;
}

function isEmptyOrSpaces(str) {
    return str === null || str.match(/^ *$/) !== null;
}