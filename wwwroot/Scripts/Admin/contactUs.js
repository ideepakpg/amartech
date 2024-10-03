async function submitContactUs() {
    debugger
    const requestData = {
        Name: document.getElementById('name').value,
        Mobile: document.getElementById('mobile').value,
        Subject: document.getElementById('subject').value,
        Message: document.getElementById('message').value,
    };

    const { Name, Mobile, Subject, Message } = requestData;
    if (!Name || !Mobile || !Subject || !Message) {
        alert('Please fill in all fields before submitting');
        return;
    }

    if (!/^[a-zA-Z\s]+$/.test(Name)) {
        alert('Please enter a valid name');
        return;
    }

    if (!/^\d{10,15}$/.test(Mobile)) {
        alert('Please enter a valid mobile number');
        return;
    }

    try {
        const response = await fetch('/Contact/SubmitContactUs', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(requestData),
        });

        if (response.ok) {
            alert('Your message has been sent successfully!');
            document.getElementById('name').value = '';
            document.getElementById('mobile').value = '';
            document.getElementById('subject').value = '';
            document.getElementById('message').value = '';
        } else {
            alert('An error occurred while sending your message.');
        }
    } catch (error) {
        console.error('Error:', error);
        alert('An unexpected error occurred.');
    }
}
