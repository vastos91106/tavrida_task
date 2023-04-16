const host = "http://localhost:5229/api/";

export const httpCall = (url) => fetch(join(url));

const join = (url) => host + url;