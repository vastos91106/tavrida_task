import {httpCall} from "./http";

const getByCompanyBinarySignUrl = "companybranch/by-company-branch-sign";

export async function getByCompanyBinarySign() {
    const response = await httpCall(getByCompanyBinarySignUrl);

    const result = {
        success: false,
        companyBranches: [],
        error: null
    };

    if (response.status === 200) {
        result.success = true;
        const data = await response.json();
        result.companyBranches = data.companyBranches;
    } else {
        result.success = false;
        result.error = "error occurred";
    }

    return result;
}