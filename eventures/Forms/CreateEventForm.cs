private bool ValidateForm()
{
    bool isValid = true;

    // Validate Event Name
    if (string.IsNullOrWhiteSpace(txtEventName.Text))
    {
        txtEventName.BorderColorIdle = Color.Red;
        MessageBox.Show("Please enter an event name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }
    else
    {
        txtEventName.BorderColorIdle = Color.FromArgb(1, 88, 122);
    }

    // Validate Description
    if (string.IsNullOrWhiteSpace(txtDescription.Text))
    {
        txtDescription.BorderColorIdle = Color.Red;
        MessageBox.Show("Please enter an event description", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }
    else
    {
        txtDescription.BorderColorIdle = Color.FromArgb(1, 88, 122);
    }

    // Validate Event Date
    if (dateEventDate.Value.Date < DateTime.Now.Date)
    {
        dateEventDate.BorderColorIdle = Color.Red;
        MessageBox.Show("Event date cannot be in the past", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }
    else
    {
        dateEventDate.BorderColorIdle = Color.FromArgb(1, 88, 122);
    }

    // Validate Location
    if (string.IsNullOrWhiteSpace(txtLocation.Text))
    {
        txtLocation.BorderColorIdle = Color.Red;
        MessageBox.Show("Please enter an event location", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }
    else
    {
        txtLocation.BorderColorIdle = Color.FromArgb(1, 88, 122);
    }

    // Validate Capacity
    if (!int.TryParse(txtCapacity.Text, out int capacity) || capacity <= 0)
    {
        txtCapacity.BorderColorIdle = Color.Red;
        MessageBox.Show("Please enter a valid capacity (must be a positive number)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }
    else
    {
        txtCapacity.BorderColorIdle = Color.FromArgb(1, 88, 122);
    }

    // Validate Category
    if (dropCategory.SelectedIndex == -1)
    {
        dropCategory.BorderColorIdle = Color.Red;
        MessageBox.Show("Please select an event category", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }
    else
    {
        dropCategory.BorderColorIdle = Color.FromArgb(1, 88, 122);
    }

    return isValid;
}