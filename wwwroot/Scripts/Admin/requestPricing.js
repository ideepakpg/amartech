async function submitPricingRequest() {
    debugger
    const requestData = {
        Name: document.getElementById('name').value,
        Email: document.getElementById('email').value,
        Mobile: document.getElementById('mobile').value,
        Service: document.getElementById('service').options[document.getElementById('service').selectedIndex].text,
        SpecialNote: document.getElementById('specialNote').value,
    };

    const { Name, Email, Mobile, Service, SpecialNote } = requestData;
    if (!Name || !Email || !Mobile || Service === 'Select a service' || !SpecialNote) {
        alert('Please fill in all fields before submitting');
        return;
    }

    if (!/^[a-zA-Z\s]+$/.test(Name)) {
        alert('Please enter a valid name');
        return;
    }

    if (!/^\S+@\S+\.\S+$/.test(Email)) {
        alert('Please enter a valid email address');
        return;
    }

    if (!/^\d+$/.test(Mobile)) {
        alert('Please enter a valid mobile number');
        return;
    }

    try {
        const response = await fetch('/RequestPricing/SubmitRequestPricing', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(requestData),
        });

        if (response.ok) {
            alert('Your request has been submitted successfully!');
            document.getElementById('name').value = '';
            document.getElementById('email').value = '';
            document.getElementById('mobile').value = '';
            document.getElementById('service').selectedIndex = 0;
            document.getElementById('specialNote').value = '';
        } else {
            alert('An error occurred while submitting your request.');
        }
    } catch (error) {
        console.error('Error:', error);
        alert('An unexpected error occurred.');
    }
}
